using System;
using System.Threading;

namespace SWTGr16Handin2
{
    public interface IDoor
    {
        public event EventHandler<EventArgDoorOpen> DoorOpenEvent; //<-- ikke sikker på denne 
        //--Det tror jeg er helt Rigtigt kerse! :-*

       //public bool DoorOpen { get; set; }
        
        public void LockDoor();

        public void UnlockDoor();

        public void OpenDoor();

        public void CloseDoor();

    }
}