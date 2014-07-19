namespace BullsAndCows
{
    using System;
    using System.Linq;

    class CheckNumber
    {
        public bool isNumber(string num)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Char.IsDigit(num[i]))
                {
                    count++;
                }
            }
            if (count == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
