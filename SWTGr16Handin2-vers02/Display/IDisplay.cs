using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2_vers02.Display
{
    public interface IDisplay
    {
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
