using System;
using System.Collections.Generic;
using System.Text;
using NSubstitute;
using SWTGr16Handin2;
using NUnit.Framework;

namespace NUnitTestChargingCabinetSWT16
{
    [TestFixture]
    public class TestDisplay
    {
        private IDisplay _display;
        private IDoor _door;



        [SetUp]

        public void SetUp()
        {
            _display = Substitute.For<IDisplay>();
            
            
        }

    }

}
