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
                else
                {
                    continue;
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

        public void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
        {
            List<int> bullIndexes = new List<int>();
            List<int> cowIndexes = new List<int>();
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
                for (int index = 0; index < secretNumber.Length; index++)
                {
                    if ((i != index) && !bullIndexes.Contains(index) && !cowIndexes.Contains(index) && !bullIndexes.Contains(i))
                    {
                        if (guessNumber[i].Equals(secretNumber[index]))
                        {
                            cowIndexes.Add(index);
                            cows++;
                            break;
                        }
                    }
                }
            }
        }
    }
}
