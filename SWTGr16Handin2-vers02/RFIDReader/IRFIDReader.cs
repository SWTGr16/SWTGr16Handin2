using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public interface IRFIDReader
    {
        event EventHandler<EventArgReader> IdReaderEvent;

        void Read(string id);
    }
}
