namespace BullsAndCows.ObserverPattern
{
    using System;

    public interface IObservable
    {
        int NotifyBullRevealed();

        int NotifyCowRevealed();
    }
}
