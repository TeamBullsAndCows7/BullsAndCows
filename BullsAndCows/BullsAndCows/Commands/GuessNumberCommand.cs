namespace BullsAndCows.Commands
{
    public class GuessNumberCommand : ICommand
    {
        private int guessNumber;

        public GuessNumberCommand(int userNumber)
        {
            this.guessNumber = userNumber;
        } 

        public CommandType Type
        {
            get { return CommandType.GuessNumber; }
        }

        public void Execute()
        {
            Observer.Observer.CommmandGuessNumberExecuted(this.guessNumber);
        }
    }
}
