
namespace BullsAndCows.Commands
{
    class TopCommand : ICommand
    {
        public CommandType Type
        {
            get { return CommandType.Top; }
        }

        public void Execute()
        {
            Observer.Observer.CommandTopExecuted();
        }
    }
}
