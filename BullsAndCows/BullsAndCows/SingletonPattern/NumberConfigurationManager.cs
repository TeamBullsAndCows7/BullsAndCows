using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public sealed class NumberConfigurationManager
    {
        private static NumberConfigurationManager instance;
        private static object holder = new Object();

        private NumberConfigurationManager()
        {

        }

        public static NumberConfigurationManager GetInstance
        {
            get
            {
                lock (holder)
                {
                    if (instance == null)
                    {
                        instance = new NumberConfigurationManager();
                    }
                }

                return instance;
            }
        }

        public string GenerateRandomSecretNumber()
        {
            StringBuilder secretNumber = new StringBuilder();
            Random rand = new Random();
            while (secretNumber.Length != 4)
            {
                int number = rand.Next(0, 10);
                secretNumber.Append(number.ToString());
            }
            return secretNumber.ToString();
        }
    }
}
