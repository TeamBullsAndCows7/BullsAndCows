namespace BullsAndCows.Messenger
{
    public abstract class MessengerDecorator : IMessenger
    {
        public MessengerDecorator(IMessenger messenger)
        {
            this.Messenger = messenger;
        }

        public IMessenger Messenger { get; private set; }

        public virtual void ShowStartGameMessage()
        {
            this.Messenger.ShowStartGameMessage();
        }

        public virtual void ShowRequestInputMessage()
        {
            this.Messenger.ShowRequestInputMessage();
        }

        public virtual void ShowRevealNumberMessage(string number)
        {
            this.Messenger.ShowRevealNumberMessage(number);
        }

        public virtual void ShowWrongGuessMessage(int bulls, int cows)
        {
            this.ShowWrongGuessMessage(bulls, cows);
        }

        public virtual void ShowTopScoreBoardMessage(string message)
        {
            this.ShowTopScoreBoardMessage(message);
        }

        public virtual void ShowInputErrorMessage()
        {
            this.ShowInputErrorMessage();
        }

        public virtual void ShowWinGameMessage(int attemps)
        {
            this.ShowWinGameMessage(attemps);
        }

        public virtual void ShowWinGameMessage(int guessAttemps, int helpCalled)
        {
            this.ShowWinGameMessage(guessAttemps, helpCalled);
        }

        public virtual void ShowEnterYourNameMessage()
        {
            this.ShowEnterYourNameMessage();
        }

        public virtual void ShowExitMessage()
        {
            this.ShowExitMessage();
        }
    }
}
