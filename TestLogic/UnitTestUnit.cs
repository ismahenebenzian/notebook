using Logic;
using System.Collections.Generic;
using Xunit;

namespace TestLogic
{
    public class UnitTestUnit
    {
        [Fact]
        public void TestUnitCreation()
        {
            // On crée une unité
            Unit unit = new Unit();

            // On demande la liste des modules
            var list = unit.ListModules();

            // On vérifie qu'elle est vide et non nulle
            Assert.Empty(list);
        }
    }
}