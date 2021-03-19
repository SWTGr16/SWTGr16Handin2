namespace SWTGr16Handin2
{
    public class ChargeControl
    {
        public bool Connected { get; }
        private double current;
        private IUsbCharger _usbCharger;

        public ChargeControl(IUsbCharger usbCharger)
        {
            _usbCharger = usbCharger;
        }

        public void StartCharge()
        {
            _usbCharger.StartCharging();
        }
        public void StopCharge()
        {
            _usbCharger.StopCharging();
        }
    }
}