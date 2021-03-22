using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public class RFIDReader : IRFIDReader
    {

        public event EventHandler<EventArgReader> IdReaderEvent;

        public void Read(string id)
        {
            OnDetectedId(new EventArgReader { ReadId = id });
        }

        protected virtual void OnDetectedId(EventArgReader e)
        {
            IdReaderEvent?.Invoke(this, e);
        }
    }
}
