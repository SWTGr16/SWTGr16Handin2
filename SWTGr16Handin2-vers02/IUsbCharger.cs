﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public interface IUsbCharger
    {
        public void StartCharging();
        public void StopCharging();
    }
}
