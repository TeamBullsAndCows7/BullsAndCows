namespace BullsAndCows.Messenger
{
    public interface IMessenger
    {
        void ShowStartGameMessage();
        void ShowRequestInputMessage();
        void ShowRevealNumberMessage(string number);
        void ShowWrongGuessMessage(int bulls, int cows);
        void ShowTopScoreBoardEmptyMessage();
        void ShowInputErrorMessage();
        void ShowWinGameMessage(int guessAttemps);
        void ShowWinGameMessage(int guessAttemps, int helpCalled);
        void ShowExitMessage();
    }
}
