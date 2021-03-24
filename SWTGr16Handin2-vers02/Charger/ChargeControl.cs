namespace SWTGr16Handin2
{
    public class ChargeControl : IChargeControl
    {
        public bool Connected { get; set; }
        public double Current { get; set; }
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
            Current = e.Current;
            if (Current > 0 && Current <= 5)
            {
                _display.PrintFullyCharged();
            }
            else if (Current > 5 && Current <= 500)
            {
                _display.PrintChargingOn();
            }
            else if (Current > 500)
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