﻿namespace SWTGr16Handin2
{
    public class ChargeControl
    {
        public bool Connected { get; }
        private double current;
        private IUsbCharger _usbCharger;
        private IDisplay _display;
      

        public ChargeControl(IUsbCharger usbCharger, IDisplay display)
        {
           
            _usbCharger = usbCharger;
            _display = display;
            _usbCharger.ChargeControlEvent += HandleChargeControlEvent;
        }

        private void HandleChargeControlEvent(object sender, EventArgChargeControl e)
        {
            current = e.Current;
            // Her mangler at den kalder metoden HandleChargeControlEvent i StationControl. Problemet er at vi får lavet et loop og det bliver noget rod.. 
            // Alternativt kan den her klasse kalde metoder i displayet- det har Leahs venner gjort. I det tilfælde skal hele metoden inde i StationControl slettes. 
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