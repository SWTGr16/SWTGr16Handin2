﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public class EventArgReader : EventArgs
    {
        public string ReadId { get; set; }
    }

    public class EventArgChargeControl : EventArgs
    {
        public double Current { get; set; }
    }

}
