namespace BullsAndCows.Utils
{
    public class ValidNumberChecker
    {
        public static bool IsValidBullsAndCowsNumber(string number)
        {
            bool isValid = number.Length == 4 && number[0] != '0';

            return isValid;
        }
    }
}
