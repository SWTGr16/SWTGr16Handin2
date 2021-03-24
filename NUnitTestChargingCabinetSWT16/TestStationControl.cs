using NUnit.Framework;
using SWTGr16Handin2;
using NSubstitute;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestStationControl
    {
        private IDisplay _display;
        private IDoor _door;
        private IRFIDReader _rfidReader;
        private IChargeControl _charger;
        private ILog _log;


        private StationControl _uutS;
        //private ChargeControl _uutC;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _charger = Substitute.For<IChargeControl>();
            _log = Substitute.For<ILog>();

            _rfidReader = Substitute.For<IRFIDReader>();

            _uutS = new StationControl(_door,_rfidReader,_display,_charger,_log);
            // _uutC = new ChargeControl();
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

        [Test]
        public void Test_that_enum_changes_to_DoorOpen_when_DoorState_equals_true()
        {
            _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = true });
            Assert.That(_uutS._state,Is.EqualTo(StationControl.LadeskabState.DoorOpen));
        }

        [TestCase("Ole")]
        public void Test_that_HandleRfidDetected_is_called(string readId)
        {
            _rfidReader.IdReaderEvent += Raise.EventWith(new EventArgReader {ReadId = readId});
            Assert.That(_uutS.NewId,Is.EqualTo(readId));
        }
        
    }
}