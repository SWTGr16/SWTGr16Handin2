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
        private IUsbCharger _charger;
        private ILog _log;


        private StationControl _uutS;
        //private ChargeControl _uutC;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _charger = Substitute.For<IUsbCharger>();
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
    }
}