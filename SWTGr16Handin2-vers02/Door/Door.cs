using System;
using System.Collections.Generic;
using System.Text;
using SWTGr16Handin2;

namespace SWTGr16Handin2
{
    public class Door : IDoor
    {
        public event EventHandler<EventArgDoorOpen> DoorLockedEvent; //rename til DoorOpen tror jeg 
        
       // public bool DoorLocked { get; set; }
        public bool DoorOpen { get; set; } // Tilføjet af Annesofie

        private bool oldDoorState; //<-- rykket fra IDoor til her fordi interface ikke kunne tage det


        public void LockDoor()
        {
            
            Console.WriteLine("Døren er låst");
        }
        

        //enum LadeskabState

        public void UnlockDoor()
        {  
            Console.WriteLine("Døren er åben");
            
        }
        // Tilføjet af Annesofie-- er ikke sikker på de skal være der 

        protected virtual void OnDoorOpen(EventArgDoorOpen e)
        {
            DoorLockedEvent?.Invoke(this, e);
        }

        public void OpenDoor()
        {
            OnDoorOpen(new EventArgDoorOpen { DoorOpen = true });
        }

        public void CloseDoor()
        {
            OnDoorClosed(new EventArgDoorOpen { DoorOpen = false });
        }

        protected virtual void OnDoorClosed(EventArgDoorOpen e)
        {
            DoorLockedEvent?.Invoke(this, e);
        }



        
    }
}
