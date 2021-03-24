using System;
using System.Collections.Generic;
using System.Text;

namespace SWTGr16Handin2
{
    public interface IChargeControl
    {
        public bool Connected { get; set; }

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
