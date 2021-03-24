using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public class Display : IDisplay
    {
        public event EventHandler<EventArgChargeControl> IChargeControlEvent; // tilføjet denne, men i tvivl


        public void PrintConnectDevice()
        {
            Console.WriteLine("Tilslut mobiltelefon");
        }

        public void PrintScanRfid()
        {
            Console.WriteLine("Scan RFID");
        }

        public void PrintConnectionError()
        {
            Console.WriteLine("Fejl ved tilslutning \r\n Prøv at tilslutte mobiltelefonen igen");
        }

        public void PrintBusy()
        {
            Console.WriteLine("Skabet er optaget");
        }

        public void PrintRfidFail()
        {
            Console.WriteLine("Fejl ved scanning af RFID \r\nPrøv igen");
        }

        public void PrintRemoveDevice()
        {
            Console.WriteLine("Tag mobiltelefonen");
        }

        public void PrintChargingOn()
        {
            Console.WriteLine("Opladningen er i gang");
        }

        public void PrintFullyCharged()
        {
            Console.WriteLine("Fuldt opladt");
        }
    }
}
