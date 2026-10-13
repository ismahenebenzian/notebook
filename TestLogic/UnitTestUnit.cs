using Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    public class UnitTestUnit
    {
        [Fact]
        public void TestUnitCreation()
        {
            Unit unit = new Unit();
            var list = unit.ListModules();
            Assert.Empty(list);
        }
    }
}
