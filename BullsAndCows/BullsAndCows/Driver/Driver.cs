namespace BullsAndCows.Driver
{
    using BullsAndCows.Commands;
    using BullsAndCows.Utils;
    using System;

    public class Driver : IDriver
    {
        private ScoreBoard scoreBoard;
        private RandomNumberGenerator randomNumberGenerator;
        private ICommand currentCommand;
        private int secretNumber;

        public Driver()
        {
            this.scoreBoard = new ScoreBoard();
            this.randomNumberGenerator = RandomNumberGenerator.Instance;
            this.secretNumber = this.randomNumberGenerator.Next();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game.\nPlease try to guess my secret 4-digit number.\n\n");
            Console.WriteLine("Use one of the following command: ");
            Console.WriteLine("\r'top' - view the top scoreboard.");
            Console.WriteLine("\r'restart' - start a new game.");
            Console.WriteLine("\r'help' - reveal a number.");
            Console.WriteLine("\r'exit' - quit the game.");


        }

        public void Stop()
        {

        }

        public void Restart()
        {
            this.secretNumber = randomNumberGenerator.Next();
        }

        private void ReadUserInput()
        {
            
        }
    }
}
