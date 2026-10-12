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
    }
}
