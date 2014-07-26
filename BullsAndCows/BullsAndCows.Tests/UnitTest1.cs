using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BullsAndCows.Utils;
using BullsAndCows.Logic;

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
        public void TestMetod2()
        {
           
        }

        [TestMethod]
        public void TestScoreBoardSeveralPlayersWithSameScore()
        {
            ScoreBoard sc = new ScoreBoard();

            sc.Enter(1, "Pesho");
            sc.Enter(2, "Mitko");
            sc.Enter(2, "Dimitar");

            string actual = sc.ToString();
            string expected = "\nTop Score Board:\n1. Pesho --> 1 guesses\n2. Mitko --> 2 guesses\n2. Dimitar --> 2 guesses\n";

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestScoreBoardEnterMethod()
        {
            ScoreBoard sc = new ScoreBoard();

            sc.Enter(1, "Mitko");
            sc.Enter(2, "Niki");
            sc.Enter(3, "Conko");
            sc.Enter(4, "Viki");
            sc.Enter(5, "Viki");

            bool actual = sc.HasToSaveScore(6);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestScoreBoardEmptyList()
        {
            ScoreBoard sc = new ScoreBoard();

            string actual = sc.ToString();
            string expected = "\nTop Score Board:\n\n-- Score Board is Empty --\n";

            Assert.AreEqual(expected, actual);
        }

        public void CheckTimesCommandHelpEvent()
        {
            string errorMessage = "You have already cheated all four digits";
            NormalLogic newChecker = new NormalLogic();
            try
            {
                newChecker.OnCommandHelpEvent();
            }
            catch (Exception e)
            { 
                Assert.Fail(e.Message, errorMessage);
            }
        }
    }
}
