namespace SWTGr16Handin2
{
    public class ChargeControl : IChargeControl
    {
        public double CurrentValue
        {
            get { return _usbCharger.CurrentValue;}
            set { _usbCharger.CurrentValue = value; }
        }
        private IUsbCharger _usbCharger;
        private IDisplay _display;
        public bool Connected
        {
            get { return _usbCharger.Connected; }
            set { _usbCharger.Connected = value; }
        }
        
        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
            _usbCharger = usbCharger;
            _display = display;
            _usbCharger.ChargeControlEvent += HandleChargeControlEvent;
        }


        public void HandleChargeControlEvent(object sender, EventArgChargeControl e)
        {
            CurrentValue = e.Current;
            if (CurrentValue > 0 && CurrentValue <= 5)
            {
                _display.PrintFullyCharged();
            }
            else if (CurrentValue > 5 && CurrentValue <= 500)
            {
                _display.PrintChargingOn();
            }
            else if (CurrentValue > 500)
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