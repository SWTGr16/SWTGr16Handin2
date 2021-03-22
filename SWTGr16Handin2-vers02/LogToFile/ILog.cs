using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2_vers02.LogToFile
{
    public interface ILog
    {
        void DoorLocked(string id);

        void DoorUnlocked(string id);
    }
}
