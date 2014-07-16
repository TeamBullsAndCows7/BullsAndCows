using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BullsAndCows.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestRandomNumberGenerator()
        {
            var randomNumberGenerator = RandomNumberGenerator.Instance;

            for (int i = 0; i < 1000; ++i)
            {
                int number = randomNumberGenerator.Next();

                int expectedLength = 4;
                int actualLenght = number.ToString().Length;

                Assert.AreEqual(expectedLength, actualLenght);
            }
        }
    }
}
