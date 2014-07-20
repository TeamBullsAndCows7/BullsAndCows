namespace BullsAndCows.Observer
{
    public interface IObservable
    {
        void OnCommandHelpEvent();

        void OnCommandRestartEvent();

        void OnCommandTopEvent();

        void OnCommandExitEvent();

        void OnCommmandGuessNumberEvent();
    }
}
