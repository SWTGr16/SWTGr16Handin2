using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using SWTGr16Handin2;
using NSubstitute;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestRFIDReader
    {
        private IRFIDReader _uut;
        private EventArgReader _eventArgReader;
        private int numberOfEvents;

        [SetUp]
        public void Setup()
        {
            _eventArgReader = null;
            numberOfEvents = 0;

            _uut = new RFIDReader();

            _uut.Read("1234");

            _uut.IdReaderEvent

                +=
                (o, args) =>
                {
                    _eventArgReader = args;
                    numberOfEvents++;
                };
        }

        [Test]
        public void IDScan_NewIDValue_EventFired()
        {
            _uut.Read("4321");
            Assert.That(_eventArgReader, Is.Not.Null);
        }


        [TestCase("2345")]
        [TestCase("5432")]
        [TestCase("7890")]
        public void ScanId_IdSetToNewValue_CorrectNewIdReceived(string newId)
        {
            _uut.Read(newId);
            Assert.That(_eventArgReader.ReadId, Is.EqualTo(newId));
        }

        [Test]
        public void MultipleScans_ReadIDIsEqualToLatestScannedID()

        {
            _uut.Read("1234");
            _uut.Read("2345");
            _uut.Read("3456");
            Assert.That(_eventArgReader.ReadId, Is.EqualTo("3456"));
        }

        [Test]
        public void IDScanned_IsEventFired()
        {
            _uut.Read("1234");
            Assert.That(numberOfEvents,Is.EqualTo(1));
        }


}
}
