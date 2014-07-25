namespace BullsAndCows.Commands
{
    public class HelpCommand : ICommand
    {
        public CommandType Type
        {
            get { return CommandType.Help; }
        }

        public void Execute()
        {
            Observer.Observer.CommandHelpExecuted();
        }
    }
}
