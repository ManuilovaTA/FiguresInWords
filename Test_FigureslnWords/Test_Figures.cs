using System;
using FiguresInWords;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_FigureslnWords
{
    [TestClass]
    public class Test_Figures
    {
        [TestMethod]
        public void Test_ThreeDigit()
        {
            Figures figures = new Figures();

            string expectedResult = "девятьсот восемьдесят шесть";

            string actualResult = figures.threeDigit(986);

            Assert.AreEqual(expectedResult, actualResult);

        }

        [TestMethod]
        public void Test_setRange()
        {
            Figures figures = new Figures();

            string expectedResult = "квадриллионов";

            string actualResult = figures.setRange(986, 4);

            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
