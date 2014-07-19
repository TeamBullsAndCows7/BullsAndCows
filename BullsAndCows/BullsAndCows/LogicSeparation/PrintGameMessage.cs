namespace BullsAndCows
{
    using System;
    using System.Linq;

    class PrintGameMessage
    {
        public void StartGame()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' " +
                              "to cheat and 'exit' to quit the game.");
        }
    }
}
