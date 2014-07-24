namespace BullsAndCows.Utils
{
    public static class ValidNumberChecker
    {
        private static bool CheckIfNumberConsistsOfDifferentDigits(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                for (int j = i + 1; j < number.Length; j++)
                {
                    if (number[i] == number[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool IsValidBullsAndCowsNumber(string number)
        {
            bool isValid = number.Length == 4 &&
                number[0] != '0' &&
                CheckIfNumberConsistsOfDifferentDigits(number);

            return isValid;
        }
    }
}
