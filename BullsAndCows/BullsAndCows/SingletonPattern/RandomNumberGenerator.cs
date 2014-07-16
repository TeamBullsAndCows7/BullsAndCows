namespace BullsAndCows
{
    using System;
    using System.Text;

    public sealed class RandomNumberGenerator
    {
        private const int MinNumber = 0;
        private const int MaxNumber = 9;

        private static RandomNumberGenerator instance;
        private Random random;

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
            int numberOfDigits = 4;

            StringBuilder sb = new StringBuilder(numberOfDigits);
            for (int i = 0; i < 4; ++i)
            {
                sb.Append(this.random.Next(MinNumber, MaxNumber));
            }

            int randomNumber = int.Parse(sb.ToString());
            return randomNumber;
        }
    }
}
