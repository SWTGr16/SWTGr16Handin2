using NUnit.Framework;
using SWTGr16Handin2;
using NSubstitute;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class Tests
    {
        private IDisplay _display;
        private IDoor _door;
        private IRFIDReader _rfidReader;
        private IChargeControl _charger;
        private ILog _log;

        private StationControl _uutS;


        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _charger = Substitute.For<IChargeControl>();
            _log = Substitute.For<ILog>();
            _rfidReader = Substitute.For<IRFIDReader>();

            _uutS = new StationControl(_door,_rfidReader,_display,_charger,_log);

           



        }

        [Test]
        public void Test_that_PrintConnect_Iscalled_when_DoorOpen_equals_true()
        {
            _uutS.HandleDoorEvent(_door, new EventArgDoorOpen{DoorOpen = true});
            _display.Received(1).PrintConnectDevice();
        }

        [Test]
        public void Test_that_PrintScanRfid_Iscalled_when_DoorOpen_equals_false()
        {
            _uutS.HandleDoorEvent(_door, new EventArgDoorOpen { DoorOpen = false });
            _display.Received(1).PrintScanRfid();
        }

        [TestCase (true)]
        [TestCase(false)]
        public void Test_that_HandleDoorEvent_is_called(bool state)
        {
            _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen {DoorOpen = state});
            Assert.That(_uutS.DoorState, Is.EqualTo(state));
        }

        //[Test]
        //public void Test_that_enum_changes_to_DoorOpen_when_DoorState_equals_true()
        //{
        //    _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = true });
        //    Assert.That(_uutS._state,Is.EqualTo(StationControl.LadeskabState.DoorOpen));
        //}

        [TestCase("Ole")]
        public void Test_that_HandleRfidDetected_is_called(string readId)
        {
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader {ReadId = readId});
            Assert.That(_uutS.NewId,Is.EqualTo(readId));
        }

        [Test]
        public void LockDoor_StartCharge_PrintChargingOn_DoorLocked_are_called_when_chargeControl_Connected_is_true()
        {
            
            _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = false });
            _charger.Connected = true;
            _rfidReader.IdReaderEvent+= Raise.EventWith(new EventArgReader{ReadId="id" });
            _door.Received(1).LockDoor();
            _charger.Received(1).StartCharge();
            _display.Received(1).PrintChargingOn();
            _log.Received(1).DoorLocked("id");


       }

        //[Test]
        //public void State_is_equal_to_LadeskabsState_Locked_when_ChargeControlConnected_is_true()
        //{
            
        //    _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = false });
        //    _charger.Connected = true;
        //    _uutS.RfidDetected("id");
        //    Assert.That(_uutS._state,Is.EqualTo(StationControl.LadeskabState.Locked));
        //}

        [Test]
        public void PrintConnectionError_is_called_when_ChargeControlConnected_is_false()
        {
            
            _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = false });
            _charger.Connected = false;
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader { ReadId = "id" });
            _display.Received(1).PrintConnectionError();
        }

        [Test]
        public void StopCharge_UnlockDoor_PrintRemoveDevice_are_called_when_state_is_locked()
        { 
            _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = false });
            _charger.Connected = true;
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader { ReadId = "id" });
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader { ReadId = "id" });
            _door.Received(1).UnlockDoor();
            _charger.Received(1).StopCharge();
            _display.Received(1).PrintRemoveDevice();
            _log.Received(1).DoorUnlocked("id");
        }

        [Test]
        public void PrintRfidFail_is_called_when_state_is_locked()
        {
            
            _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = false });
            _charger.Connected = true;
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader { ReadId = "id" });
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader { ReadId = "fakeId" });
            _display.Received(1).PrintRfidFail();
        }

        [Test]
        public void Break_when_state_is_DoorOpen()
        {
         
            _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = true });
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader { ReadId = "fakeID" });
           
        }



    }
}