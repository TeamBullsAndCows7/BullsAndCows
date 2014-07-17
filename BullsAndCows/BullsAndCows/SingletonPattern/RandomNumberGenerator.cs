namespace BullsAndCows.SingletonPattern
{
    using System;
    using System.Text;

    public sealed class RandomNumberGenerator
    {
        private const int MinNumber = 0;
        private const int MaxNumber = 9;

        private static readonly RandomNumberGenerator instance = new RandomNumberGenerator();
        private readonly Random random;

        private RandomNumberGenerator()
        {
            this.random = new Random();
        }

        public static RandomNumberGenerator Instance
        {
            get
            {                            
                return instance;
            }
        }

        public int NextNumber()
        {
            int numberOfDigits = 4;

            StringBuilder sb = new StringBuilder(numberOfDigits);
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    sb.Append(this.random.Next(1, RandomNumberGenerator.MaxNumber + 1)); // 0 can't be at position 1
                }
                else
                {
                    sb.Append(this.random.Next(RandomNumberGenerator.MinNumber,
                        RandomNumberGenerator.MaxNumber + 1));
                }
            }

            int randomNumber = int.Parse(sb.ToString());
            return randomNumber;
        }

        public int NextDigit(int min, int max)
        {
            return this.random.Next(min, max);
        }
    }
}
