namespace BullsAndCows.Messenger
{
    using System;

    public class ColoredMessenger : MessengerDecorator
    {
        private const ConsoleColor DefaultColor = ConsoleColor.DarkYellow;
        private const ConsoleColor ErrorColor = ConsoleColor.Red;
        private const ConsoleColor GameWonColor = ConsoleColor.Green;

        public ColoredMessenger(DefaultMessenger messenger)
            : base(messenger)
        {
        }

        public override void ShowStartGameMessage()
        {
            Console.ForegroundColor = ColoredMessenger.DefaultColor;
            base.ShowStartGameMessage();
        }

        public override void ShowRequestInputMessage()
        {
            Console.ForegroundColor = ColoredMessenger.DefaultColor;
            base.Messenger.ShowRequestInputMessage();
        }

        public override void ShowRevealNumberMessage(string number)
        {
            Console.ForegroundColor = ColoredMessenger.DefaultColor;
            base.Messenger.ShowRevealNumberMessage(number);
        }

        public override void ShowWrongGuessMessage(int bulls, int cows)
        {
            Console.ForegroundColor = ColoredMessenger.ErrorColor;
            base.Messenger.ShowWrongGuessMessage(bulls, cows);
        }

        public override void ShowTopScoreBoardMessage(string message)
        {
            Console.ForegroundColor = ColoredMessenger.ErrorColor;
            base.Messenger.ShowTopScoreBoardMessage(message);
        }

        public override void ShowInputErrorMessage()
        {
            Console.ForegroundColor = ColoredMessenger.ErrorColor;
            base.Messenger.ShowInputErrorMessage();
        }

        public override void ShowWinGameMessage(int attemps)
        {
            Console.ForegroundColor = ColoredMessenger.GameWonColor;
            base.Messenger.ShowWinGameMessage(attemps);
        }

        public override void ShowWinGameMessage(int guessAttemps, int helpCalled)
        {
            Console.ForegroundColor = ColoredMessenger.GameWonColor;
            base.Messenger.ShowWinGameMessage(guessAttemps, helpCalled);
        }

        public override void ShowEnterYourNameMessage()
        {
            Console.ForegroundColor = ColoredMessenger.GameWonColor;
            base.Messenger.ShowEnterYourNameMessage();
        }

        public override void ShowExitMessage()
        {
            Console.ForegroundColor = ColoredMessenger.DefaultColor;
            base.Messenger.ShowExitMessage();
        }
    }
}
