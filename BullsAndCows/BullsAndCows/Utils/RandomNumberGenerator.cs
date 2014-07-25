namespace BullsAndCows.Utils
{
    using System;
    using System.Text;

    public class RandomNumberGenerator
    {
        private static RandomNumberGenerator instance;
        private readonly Random random;     
        private const int MinNumber = 1000;
        private const int MaxNumber = 9999;

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
            return this.random.Next(MinNumber, MaxNumber);
        }
    }
}
