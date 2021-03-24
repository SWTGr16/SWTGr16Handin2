using NUnit.Framework;
using SWTGr16Handin2;
using NSubstitute;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestChargeControl
    {
        private IDisplay _display;
     
    
     
        private IUsbCharger _usbCharger; 

        private ChargeControl _uutC;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();   
            _usbCharger = Substitute.For<IUsbCharger>();
            _uutC = new ChargeControl(_usbCharger,_display);
           
        }

        [TestCase(4)]
        [TestCase(5)]
        [TestCase(1)]
        public void Test_PrintFullyCharged_isCalledWhen_current_moreThan_zero_AND_lessOrEqualTo_five(double current)
        {
            _uutC.HandleChargeControlEvent(_usbCharger, new EventArgChargeControl{Current = current});
            _display.Received(1).PrintFullyCharged();
        }

        [TestCase(6)]
        [TestCase(120)]
        [TestCase(500)]
        public void Test_PrintChargingOn_isCalledWhen_current_moreThan_5_AND_lessOrEqualTo_500(double current)
        {
            _uutC.HandleChargeControlEvent(_usbCharger, new EventArgChargeControl { Current = current });
            _display.Received(1).PrintChargingOn();
            _display.Received(0).PrintConnectDevice();
            _display.Received(0).PrintConnectionError();
            _display.Received(0).PrintFullyCharged();
            _display.Received(0).PrintRemoveDevice();
            _display.Received(0).PrintRfidFail();
            _display.Received(0).PrintScanRfid();
            _display.Received(0).PrintBusy();
        }

        [TestCase(501)]
        public void Test_PrintRemoveDevice_isCalledWhen_current_moreThan_500(double current)
        {
            _uutC.HandleChargeControlEvent(_usbCharger, new EventArgChargeControl { Current = current });
            _display.Received(1).PrintRemoveDevice();
            _display.Received(0).PrintConnectDevice();
            _display.Received(0).PrintConnectionError();
            _display.Received(0).PrintFullyCharged();
            _display.Received(0).PrintChargingOn();
            _display.Received(0).PrintRfidFail();
            _display.Received(0).PrintScanRfid();
            _display.Received(0).PrintBusy();
        }

        [TestCase(5)]
        public void HandleChargeControlEvent_CurrentIsSet(double current)
        {
            _usbCharger.ChargeControlEvent += Raise.EventWith(new EventArgChargeControl { Current = current });
            Assert.That(_uutC.Current, Is.EqualTo(current));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void HandleChargeControlEvent_ConnectedIsSet(bool state) // Vi kan lave dette, efter vi har fået hjælp af Frank i forhold til hvor Connected skal sættes i ChargeControl
        {
            _uutC.Connected = state;
            Assert.That(_uutC.Connected, Is.EqualTo(state));
        }


        [Test]
        public void StartCharging_IsCalled_When_StartCharge_IsCalled()
        { 
            _uutC.StartCharge();
            _usbCharger.Received(1).StartCharging();
        }


        [Test]
        public void StopCharging_IsCalled_When_StopCharge_IsCalled()
        {
            _uutC.StopCharge();
            _usbCharger.Received(1).StopCharging();

        }



    }
}