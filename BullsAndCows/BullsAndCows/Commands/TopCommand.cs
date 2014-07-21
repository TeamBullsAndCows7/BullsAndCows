
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
            //show score board

            Observer.Observer.CommandTopEventExecuted();
        }
    }
}
