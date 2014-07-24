namespace BullsAndCows.Utils
{
    using System;
    using System.Text;

    public class RandomNumberGenerator
    {
        private static RandomNumberGenerator instance;
        private readonly Random random;
        private const int NumberLength = 4;
        private const int MinNumber = 0;
        private const int MaxNumber = 9;

        private RandomNumberGenerator() 
        {
            this.random = new Random();
        }

        public static RandomNumberGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RandomNumberGenerator();
                }
                return instance;
            }
        }

        public int Next()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < NumberLength; i++)
            {
                int randomDigit = this.random.Next(MinNumber, MaxNumber + 1);

                if (i == 0 && randomDigit == 0)
                {
                    randomDigit++;
                }

                while (sb.ToString().IndexOf(randomDigit.ToString()) >= 0)
                {
                    randomDigit = this.random.Next(MinNumber, MaxNumber + 1);
                }

                sb.Append(randomDigit);
            }

            int generatedNumber = int.Parse(sb.ToString());

            return generatedNumber;
        }
    }
}
