namespace BullsAndCows
{
    using BullsAndCows.SingletonPattern;
    using System;
    using System.Collections.Generic;

    public class NumberManipulator
    {
        public char[] RevealNumberAtRandomPosition(RandomNumberGenerator generator, string secretnumber, char[] cheatNumber)
        {
            while (true)
            {
                int index = generator.NextDigit(0, 4);
                if (cheatNumber[index] == 'X')
                {
                    cheatNumber[index] = secretnumber[index];
                    return cheatNumber;
                }
            }
        }

        public bool CheckIfNumConsistsOnlyOfDigits(string num)
        {
            foreach (char ch in num)
            {
                if ('0' > ch || ch > '9')
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfDigitsAreDifferent(string num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                for (int j = i + 1; j < num.Length; j++)
                {
                    if (num[i] == num[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
        {
            List<int> bullIndexes = new List<int>();
            for (int i = 0; i < secretNumber.Length; i++)
            {
                if (guessNumber[i].Equals(secretNumber[i]))
                {
                    bullIndexes.Add(i);

                    bulls++;
                }
            }

            for (int i = 0; i < guessNumber.Length; i++)
            {
                if (secretNumber.IndexOf(guessNumber[i].ToString()) != -1 && bullIndexes.IndexOf(i) == -1)
                {
                    cows++;
                }
            }
        }
    }
}
