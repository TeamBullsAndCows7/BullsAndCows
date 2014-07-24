namespace BullsAndCows
{
    using BullsAndCows.Driver;

    public class BullsAndCowsProject
    {
        static void Main()
        {
            IDriver driver = new Driver.Driver();
            driver.Start();
        }
    }
}