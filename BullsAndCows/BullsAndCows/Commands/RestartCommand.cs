namespace BullsAndCows.Commands
{
    public class RestartCommand : ICommand
    {
        public CommandType Type 
        {
            get { return CommandType.Restart; }
        }

        public void Execute()
        {
            Observer.Observer.CommandRestartExecuted();
        }
    }
}
