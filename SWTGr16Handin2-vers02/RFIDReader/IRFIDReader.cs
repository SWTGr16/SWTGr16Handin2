using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    interface IRFIDReader
    {
        event EventHandler<EventArgReader> IdReaderEvent;

        void Read(string id);
    }
}
