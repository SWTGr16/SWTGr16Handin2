using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public interface ILog
    {
        void DoorLocked(string id);

        void DoorUnlocked(string id);
    }
}
