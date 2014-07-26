namespace BullsAndCows.Tests
{
    using System.Text;
    using BullsAndCows.Utils;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidBullsAndCowsNumberCheckerTest
    {
        [TestMethod]
        public void TestValidBullsAndCowsNumberCheckerFourDigitsLength()
        {
            int number = 1234;
            bool expected = true;
            bool actual = ValidBullsAndCowsNumberChecker.IsValidBullsAndCowsNumber(number.ToString());
            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestValidBullsAndCowsNumberCheckerDifferentThanFourDigitsLength()
        {
            bool isValid = false;
            int defaultNumberLength = 4;
            int maxNumberOfDigits = 10;
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= maxNumberOfDigits; i++)
            {
                sb.Append(i.ToString());

                if (i == defaultNumberLength)
                {
                    continue;
                }

                if (ValidBullsAndCowsNumberChecker.IsValidBullsAndCowsNumber(sb.ToString()))
                {
                    isValid = true;
                    break;
                }
            }

            Assert.AreEqual(false, isValid, "{0} is valid Bulls And Cows number", sb.ToString());
        }
    }
}
