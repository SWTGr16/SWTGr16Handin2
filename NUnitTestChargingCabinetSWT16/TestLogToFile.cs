using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SWTGr16Handin2;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestLogToFile
    {
        private LogToFile _uut;
        private string _fileName = "ChargingCabinetLog.txt";
        private string[] allTextLogEntries;
        private string[] inputFields;


        [SetUp]
        public void Setup()
        {
            _uut = new LogToFile();
        }

        [Test]
        public void DoorLocked_StringAtPathContainsCorrectMessageAndID()
        {
            _uut.DoorLocked("1234");
            allTextLogEntries = System.IO.File.ReadAllLines(_fileName);
            string latestEntry = allTextLogEntries[allTextLogEntries.Length - 1];
            inputFields = latestEntry.Split(':');
            // string date = inputFields[0];
            string messageLogged = inputFields[3];
            string IDLogged = inputFields[4];

            Assert.That(messageLogged, Is.EqualTo("Skab låst med id"));
            Assert.That(IDLogged, Is.EqualTo("1234"));
        }

        [Test]
        public void DoorUnLocked_StringAtPathContainsCorrectMessageAndID()
        {
            _uut.DoorUnlocked("1234");
            allTextLogEntries = System.IO.File.ReadAllLines(_fileName);
            string latestEntry = allTextLogEntries[allTextLogEntries.Length - 1];
            inputFields = latestEntry.Split(':');
            // string date = inputFields[0];
            string messageLogged = inputFields[3];
            string IDLogged = inputFields[4];

            Assert.That(messageLogged, Is.EqualTo("Skab låst op med id"));
            Assert.That(IDLogged, Is.EqualTo("1234"));


        }
    }

}

    
