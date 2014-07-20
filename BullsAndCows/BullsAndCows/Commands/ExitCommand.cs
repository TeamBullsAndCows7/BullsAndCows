
namespace BullsAndCows.Commands
{
    class ExitCommand : ICommand
    {
        public CommandType Type
        {
            get { return CommandType.Top; }
        }

        public void Execute()
        {
            //just exit
        }
    }
}
