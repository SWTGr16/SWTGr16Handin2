using System;
using System.Collections.Generic;
using System.Text;
using SWTGr16Handin2;

namespace SWTGr16Handin2_vers02
{
    public class Door : IDoor
    {
        public event EventHandler DoorLockedEvent;
        public bool DoorLocked { get; set; }

        private bool oldDoorState; //<-- rykket fra IDoor til her fordi interface ikke kunne tage det

        public void LockDoor()
        {
            
        }

        public void UnlockDoor()
        {
            
        }
    }
}
