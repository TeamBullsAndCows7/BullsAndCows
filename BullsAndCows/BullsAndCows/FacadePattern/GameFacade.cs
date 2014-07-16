namespace BullsAndCows
{
    using System.Collections.Generic;

    public class GameFacade
    {
        private Calculate bullsAndCows;
        private GameIntro gameMessage;
        private NumChecker numCheck;
        private RevealPosition revealNumber;
        private Sort sorting;

        public GameFacade()
        {
            this.bullsAndCows = new Calculate();
            this.gameMessage = new GameIntro();
            this.numCheck = new NumChecker();
            this.revealNumber = new RevealPosition();
            this.sorting = new Sort();
        }

        public void GetBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
        {
            this.bullsAndCows.CalculateBullsAndCows(secretNumber, guessNumber, ref bulls, ref cows); //not checked
        }

        public void GameMessage()
        {
            this.gameMessage.StartGame();
        }

        public bool CheckerForDigits(string num)
        {
            if (!this.numCheck.CheckNumberLength(num))
            {
                return false;
            }

            if (!this.numCheck.CheckIfNumConsistsOnlyOfDigits(num))
            {
                return false;
            }

            return true;
        }

        public char[] RevealNumber(string secretnumber, char[] cheatNumber)
        {
            return this.revealNumber.RevealNumberAtRandomPosition(secretnumber, cheatNumber);
        }

        public int Sort(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return this.sorting.SortDictionary(a, b);
        }
    }
}
