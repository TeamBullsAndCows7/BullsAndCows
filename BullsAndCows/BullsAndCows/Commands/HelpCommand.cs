
namespace BullsAndCows.Commands
{
    class HelpCommand : ICommand
    {
        public CommandType Type
        {
            get { return CommandType.Help; }
        }

        public void Execute()
        {
            //reveal number

            Observer.Observer.CommandHelpEventExecuted();
        }
    }
}
