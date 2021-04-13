    using System;
    using System.Threading.Channels;
    using SWTGr16Handin2;
    class Program
    {
        
        static void Main(string[] args)
        {
             
        // Assemble your system here from all the classes
        IRFIDReader _rfidReader = new RFIDReader();
        IDoor _door = new Door();
        IDisplay _display = new Display();
        ILog _log = new LogToFile();
        IUsbCharger _usbCharger = new UsbChargerSimulator();
        IChargeControl _chargeControl = new ChargeControl(_usbCharger, _display);
        StationControl _stationControl = new StationControl(_door,_rfidReader,_display,_chargeControl,_log);

        
        
        bool finish = false;
            do
            {
                string input;
                System.Console.WriteLine("Indtast E, O, C, R: ");
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) continue;

                switch (input[0])
                {
                    case 'E':
                        finish = true;
                        break;

                    case 'O':
                        _door.OpenDoor(); 
                        break;

                    case 'C':
                        _door.CloseDoor();  
                        break;

                    case 'R':
                        System.Console.WriteLine("Indtast RFID id: ");
                        string id = System.Console.ReadLine();
                        _rfidReader.Read(id);
                        break;

                    default:
                        break;
                }

            } while (!finish);
        }
    }


    
