namespace SWTGr16Handin2
{
    public class ChargeControl : IChargeControl
    {
        public bool Connected { get; set; }
        private double current;
        private IUsbCharger _usbCharger;
        private IDisplay _display;
      

        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            _usbCharger = usbCharger;
            _display = display;
            _usbCharger.ChargeControlEvent += HandleChargeControlEvent;
         
        }

        public void HandleChargeControlEvent(object sender, EventArgChargeControl e)
        {
            current = e.Current;
            if (current > 0 && current <= 5)
            {
                _display.PrintFullyCharged();
            }
            else if (current > 5 && current <= 500)
            {
                _display.PrintChargingOn();
            }
            else if (current > 500)
            {
                _display.PrintRemoveDevice();
            }

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