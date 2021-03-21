using System;
using System.Threading;

namespace SWTGr16Handin2
{
    interface IDoor
    {
        public event EventHandler DoorLockedEvent; //<-- ikke sikker på denne

        public bool DoorLocked { get; set; }
        
        public void LockDoor();

        public void UnlockDoor();

    }
}