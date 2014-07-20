
namespace BullsAndCows.Commands
{
    class ExitCommand : ICommand
    {
        public CommandType Type
        {
            get { return CommandType.Exit; }
        }

        public void Execute()
        {
            //just exit
        }
    }
}
