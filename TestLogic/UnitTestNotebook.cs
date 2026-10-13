using Xunit;
using Logic;
using System.Net.NetworkInformation;

namespace TestLogic
{
    public class UnitTestNotebook
    {
        [Fact]
        public void TestListUnits()
        {
            // creer carnet vide
            Notebook nb = new Notebook();

            var list = nb.ListUnits();
            Assert.NotNull(list);
            Assert.Empty(list);
        }

        [Fact]
        public void AddUnit_AjouteBienUneUnite()
        {
            Notebook nb= new Notebook();
            Unit u1 = new Unit();
            u1.Name= "Test";
            u1.Coef = 1;
            nb.AddUnit(u1);
            var units = nb.ListUnits();
            Assert.Single(units);
            Assert.Same(u1, units[0]);  
            //BONUS
            var u2 = new Unit();
            u2.Name = "Test";
            u2.Coef = 2;
            Assert.Throws<Exception>(() => { nb.AddUnit(u2); });
            u2.Name = "Test2";
            nb.AddUnit(u2);
            units=nb.ListUnits();
            Assert.Equal(2, units.Length);
            Assert.Same(u2, units[1]);
        }

        [Fact]
        public void RemoveUnit_SupprimeBienUneUnite()
        {
            Notebook nb = new Notebook();
            Unit u1 = new Unit();
            u1.Name = "Test";
            u1.Coef = 1;
            nb.AddUnit(u1);
            nb.RemoveUnit(u1);
            var units = nb.ListUnits();
            Assert.Empty(units);
        }
    }
}
