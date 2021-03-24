using NUnit.Framework;
using SWTGr16Handin2;
using NSubstitute;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestChargeControl
    {
        private IDisplay _display;
        private IDoor _door;
        private IRFIDReader _rfidReader;
        private IChargeControl _charger;
        private ILog _log;
        private IUsbCharger _usbCharger; //<-- never assigned

        private ChargeControl _uutC;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _door = Substitute.For<IDoor>();
            _charger = Substitute.For<IChargeControl>();
            _log = Substitute.For<ILog>();
            _rfidReader = Substitute.For<IRFIDReader>();

            _uutC = new ChargeControl(_usbCharger,_display);

        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(1)]
        public void Test_PrintFullyCharged_isCalledWhen_current_moreThan_zero_AND_lessOrEqualTo_five(double current)
        {
            _uutC.HandleChargeControlEvent(_charger, new EventArgChargeControl{Current = current});
            _display.Received(1).PrintFullyCharged();
        }




        //[Test]
        //public void Test_that_PrintConnect_Iscalled_when_DoorOpen_equals_true()
        //{
        //    _uutS.HandleDoorEvent(_door, new EventArgDoorOpen { DoorOpen = true });
        //    _display.Received(1).PrintConnectDevice();
        //}


    }
}