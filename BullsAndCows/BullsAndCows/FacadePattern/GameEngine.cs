namespace BullsAndCows
{
    using BullsAndCows.SingletonPattern;
    using System.Collections.Generic;

    public class GameEngine
    {
        private readonly Messenger gameMessenger = new Messenger();
        private readonly NumberManipulator numberManipulator = new NumberManipulator();
        private readonly RandomNumberGenerator randomGenerator = RandomNumberGenerator.Instance;

        private static GameEngine instance;

        public static GameEngine GetInstance()
        {
            if (instance == null)
            {
                instance = new GameEngine();
            }

            return instance;
        }

        public void GetBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
        {
            this.numberManipulator.CalculateBullsAndCows(secretNumber, guessNumber, ref bulls, ref cows);
        }

        public void StartMessage()
        {
            this.gameMessenger.StartMessage();
        }

        public bool CheckIfNumberIsValid(string num)
        {
            if (num.Length != 4)
            {
                return false;
            }

            if (!this.numberManipulator.CheckIfNumConsistsOnlyOfDigits(num))
            {
                return false;
            }

            return true;
        }

        public char[] RevealNumber(string secretnumber, char[] cheatNumber)
        {
            return this.numberManipulator.RevealNumberAtRandomPosition(this.randomGenerator, secretnumber, cheatNumber);
        }

        // I am not sure this belongs here
        public int SortDictionary(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return a.Value.CompareTo(b.Value);
        }
    }
}
