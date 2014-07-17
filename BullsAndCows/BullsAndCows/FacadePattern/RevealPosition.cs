namespace BullsAndCows
{
    using System;

    public class RevealPosition : IRandomNumber
    {
        public char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber)
        {
            while (true)
            {
                int index = this.GetRandomNumber(0, 4);
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

        public int GetRandomNumber(int min, int max)
        {
            Random rand = new Random();
            return rand.Next(min, max);
        }
    }
}
