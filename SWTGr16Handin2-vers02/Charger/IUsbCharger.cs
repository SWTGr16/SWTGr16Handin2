using System;
using System.Collections.Generic;
using System.Text;


namespace SWTGr16Handin2
{
    public interface IUsbCharger
    {
        event EventHandler<EventArgChargeControl> ChargeControlEvent;
        public void StartCharging();
        public void StopCharging();

        public bool Connected { get; set; }
        public double  CurrentValue { get; set; }

    }
}
