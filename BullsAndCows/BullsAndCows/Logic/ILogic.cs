namespace BullsAndCows.Logic
{
    using BullsAndCows.Observer;

    public interface ILogic : IObservable
    {
        bool Run { get; }
    }
}
