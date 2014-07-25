namespace BullsAndCows.Commands
{
    public interface ICommand
    {
        CommandType Type { get; }

        void Execute();
    }
}
