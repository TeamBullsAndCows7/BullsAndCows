namespace BullsAndCows.Commands
{
    public class ExitCommand : ICommand
    {
        public CommandType Type
        {
            get { return CommandType.Exit; }
        }

        public void Execute()
        {
            Observer.Observer.CommandExitExecuted();
        }
    }
}
