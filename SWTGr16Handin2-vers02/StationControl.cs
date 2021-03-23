using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWTGr16Handin2
{
    public class StationControl
    {
        
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        public enum LadeskabState //ændret til public
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private bool doorState;
        private ChargeControl _chargeControl;
        private string _oldId;
        private IDoor _door;
        private IDisplay _display;
        private IRFIDReader _reader;
        private ILog _log;
       // private string logFile = "logfile.txt"; // Navnet på systemets log-fil
        private string newId;

        // Her mangler constructor
        public StationControl(IDoor door, IRFIDReader reader)
        {
            _door = door;
            _reader = reader;
            _display = new Display();
            _log = new LogToFile();
            door.DoorOpenEvent += HandleDoorEvent;
            reader.IdReaderEvent += HandleRfidDetected;

        }

        public void HandleDoorEvent(object sender, EventArgDoorOpen e)
        {
            doorState = e.DoorOpen;

            if (doorState)
            {
                _display.PrintConnectDevice();
                _state = LadeskabState.DoorOpen; // Tror den skal sættes her. Det giver ihvertfald mest mening for mig
  
            }
            else
            {
                _display.PrintScanRfid();
               
            }
        }

        public void HandleRfidDetected(object sender, EventArgReader e)
        {
            newId = e.ReadId;
            RfidDetected(newId);
        }

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        public void RfidDetected(string id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_chargeControl.Connected)
                    {
                        _door.LockDoor();
                        _chargeControl.StartCharge();
                        _oldId = id;
                        _log.DoorLocked(id);
                       
                        _display.PrintChargingOn(); 
                       
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        _display.PrintConnectionError();
                       
                    }

                    break;

                case LadeskabState.DoorOpen:
                    // Ignore
                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _chargeControl.StopCharge();
                        _door.UnlockDoor();
                        _log.DoorUnlocked(id);                       
                        _display.PrintRemoveDevice();
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        _display.PrintRfidFail();
                    
                    }

                    break;
            }
        }

        
        
    }
}
