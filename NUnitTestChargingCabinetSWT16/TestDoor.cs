using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using SWTGr16Handin2;
using NUnit.Framework;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestDoor
    {
        private IDoor _uut;
        private EventArgDoorOpen _eventArgDoorOpen;
        private int numberOfEvents;

        [SetUp]

        public void SetUp()
        {
            _uut = new Door();
            _eventArgDoorOpen = null;
            numberOfEvents = 0;

            _uut.DoorOpenEvent
                +=
                (o, args) =>
                {
                    _eventArgDoorOpen = args;
                    numberOfEvents++;
                };
        }

        [Test]
        public void OpenDoor_event_fired()
        {
            _uut.OpenDoor();
            Assert.That(_eventArgDoorOpen,Is.Not.Null);
        }

        [Test]
        public void CloseDoor_event_fired()
        {
            _uut.CloseDoor();
            Assert.That(_eventArgDoorOpen,Is.Not.Null);
        }

        [Test]
        public void DoorOpen_set_property_DoorOpen_to_true()
        {
            _uut.OpenDoor();
            Assert.That(_eventArgDoorOpen.DoorOpen, Is.EqualTo(true));
        }

        [Test]
        public void DoorClose_set_property_DoorOpen_to_false()
        {
            _uut.CloseDoor();
            Assert.That(_eventArgDoorOpen.DoorOpen, Is.EqualTo(false));
        }



        //public void Test_that_enum_changes_to_DoorOpen_when_DoorState_equals_true()
        //{
        //    _door.DoorOpenEvent += Raise.EventWith(new EventArgDoorOpen { DoorOpen = true });
        //    Assert.That(_uutS._state, Is.EqualTo(StationControl.LadeskabState.DoorOpen));
        //}


    }
}
