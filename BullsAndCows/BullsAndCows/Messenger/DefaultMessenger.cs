namespace BullsAndCows.Messenger
{
    using System;

    public class DefaultMessenger : IMessenger
    {
        public void ShowStartGameMessage()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game.\nPlease try to guess my secret 4-digit number.\n\n");
            Console.WriteLine("Use one of the following command: ");
            Console.WriteLine("\r'top' - view the top scoreboard.");
            Console.WriteLine("\r'restart' - start a new game.");
            Console.WriteLine("\r'help' - reveal a number.");
            Console.WriteLine("\r'exit' - quit the game.");
        }

        public void ShowRequestInputMessage()
        {
            Console.Write("Enter your guess or command: ");
        }

        public void ShowRevealNumberMessage(string number)
        {
            Console.WriteLine("The number looks like {0}", number);
        }

        public void ShowWrongGuessMessage(int bulls, int cows)
        {
            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
        }

        public void ShowTopScoreBoardMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowInputErrorMessage()
        {
            Console.WriteLine("Incorrect guess or command!");
        }

        public void ShowWinGameMessage(int guessAttemps)
        {
            Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", guessAttemps);
        }

        public void ShowWinGameMessage(int guessAttemps, int helpCalled)
        {
            this.ShowWinGameMessage(guessAttemps);
            Console.WriteLine("You called for help {0} time(s) and you are not allowed to enter the top scoreboard.", helpCalled);
        }

        public void ShowEnterYourNameMessage()
        {
            Console.Write("Please enter your name for the top scoreboard: ");
        }

        public void ShowExitMessage()
        {
            Console.WriteLine("Good bye!");
        }
    }
}
