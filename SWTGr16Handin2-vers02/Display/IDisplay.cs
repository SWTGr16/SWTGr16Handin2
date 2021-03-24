using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public interface IDisplay
    {
        public event EventHandler<EventArgChargeControl> IChargeControlEvent; // tilføjet denne, men i tvivl

        public void PrintConnectDevice();

        public void PrintScanRfid();

        public void PrintConnectionError();

        public void PrintBusy();

        public void PrintRfidFail();

        public void PrintRemoveDevice();

        public void PrintChargingOn();

        public void PrintFullyCharged();
    }
}
