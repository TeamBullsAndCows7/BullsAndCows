
namespace BullsAndCows.Commands
{
    class RestartCommand : ICommand
    {
        public CommandType Type 
        {
            get { return CommandType.Restart; }
        }

        public void Execute()
        {
            //restart game
        }
    }
}
