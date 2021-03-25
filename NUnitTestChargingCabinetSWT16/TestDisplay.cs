using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NSubstitute;
using SWTGr16Handin2;
using NUnit.Framework;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestDisplay
    {
        private IDisplay _uutDisplay;
        public StringWriter stringWriter;

        [SetUp]

        public void SetUp()
        {
            _uutDisplay = new Display();
            
        }

        [Test]
        public void PrintFullyCharged_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintFullyCharged();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Fuldt opladt\r\n"));
        }

        [Test]
        public void PrintConnectDevice_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintConnectDevice();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Tilslut mobiltelefon\r\n"));
        }

        [Test]
        public void PrintBusy_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintBusy();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Skabet er optaget\r\n"));
        }

        [Test]
        public void PrintScanRfid_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintScanRfid();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Scan RFID\r\n"));
        }

        [Test]
        public void PrintConnectionError_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintConnectionError();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Fejl ved tilslutning \r\n Prøv at tilslutte mobiltelefonen igen\r\n"));
        }

        [Test]
        public void PrintRfidFail_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintRfidFail();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Fejl ved scanning af RFID \r\nPrøv igen\r\n"));
        }

        [Test]
        public void PrintRemoveDevice_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintRemoveDevice();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Tag mobiltelefonen\r\n"));
        }

        [Test]
        public void PrintChargingOn_Write()
        {
            using (stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                _uutDisplay.PrintChargingOn();
            }
            Assert.That(stringWriter.ToString(), Is.EqualTo("Opladningen er i gang\r\n"));
        }

    }

}
