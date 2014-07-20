namespace BullsAndCows.Driver
{
    using BullsAndCows.Commands;
    using BullsAndCows.Logic;
    using BullsAndCows.Utils;
    using System;

    public class Driver : IDriver
    {
        private ILogic gameLogic;

        public Driver()
        {
            this.gameLogic = new NormalLogic();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game.\nPlease try to guess my secret 4-digit number.\n");
            Console.WriteLine("Use one of the following command: ");
            Console.WriteLine("\r'top' - view the top scoreboard.");
            Console.WriteLine("\r'restart' - start a new game.");
            Console.WriteLine("\r'help' - reveal a number.");
            Console.WriteLine("\r'exit' - quit the game.");

            while (this.gameLogic.Run)
            {
                Console.Write("Enter your guess or command: ");
                string userInput = Console.ReadLine();

                try
                {
                    ICommand command = CommandFactory.Create(userInput);
                    command.Execute();    
                }
                catch (ArgumentException argumentExc)
                {
                    Console.WriteLine(argumentExc.Message);
                }           
            }
        }

        public void Stop()
        {
                    
        }

        public void Restart()
        {
            this.Stop();
            this.Start();
        }
    }
}
