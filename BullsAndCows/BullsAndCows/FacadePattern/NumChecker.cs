namespace BullsAndCows
{
    public class NumChecker
    {
        public bool CheckNumberLength(string num)
        {
            if (num.Length == 4)
            {
                return true;
            }

            return false;
        }

        public bool CheckIfNumConsistsOnlyOfDigits(string num)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!char.IsDigit(num[i]))
                {
                    return false;
                }
            }

            return true;
        }       
    }
}
