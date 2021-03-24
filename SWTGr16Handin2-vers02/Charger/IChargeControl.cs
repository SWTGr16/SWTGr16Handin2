using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public interface IChargeControl
    {
        private void HandleChargeControlEvent(object sender, EventArgChargeControl e)
        {
        }

        public void StartCharge()
        {
        }
        public void StopCharge()
        {
        }
    }
}
