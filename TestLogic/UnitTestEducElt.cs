using System;
using Logic;
using Xunit;

namespace TestLogic
{
    public class UnitTestEducElt
    {
        [Fact]
        public void TestName()
        {
            EducationalElement element = new EducationalElement();
            Assert.Throws<Exception>(() => { element.Name = ""; });
            element.Name = "maths";
            Assert.Equal("maths", element.Name);
        }

        [Fact]
        public void TestCoef()
        {
            EducationalElement element = new EducationalElement();
            Assert.Throws<Exception>(() => { element.Coef = 0; });
            element.Coef = 1.5f;
            Assert.Equal(1.5f, element.Coef, 3);
        }
    }
}