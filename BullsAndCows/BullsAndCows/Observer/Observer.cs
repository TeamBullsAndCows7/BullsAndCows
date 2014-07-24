namespace BullsAndCows.Observer
{
    using System.Collections.Generic;

    public static class Observer
    {
        private static List<IObservable> observableList;

        static Observer()
        {
            observableList = new List<IObservable>();
        }

        public static void Attach(IObservable observableObject)
        {
            observableList.Add(observableObject);
        }

        public static void Dettach(IObservable observableObject)
        {
            observableList.Remove(observableObject);
        }

        public static void CommandHelpExecuted()
        {
            foreach (var item in observableList)
            {
                item.OnCommandHelpEvent();
            }
        }

        public static void CommandRestartExecuted()
        {
            foreach (var item in observableList)
            {
                item.OnCommandRestartEvent();
            }
        }

        public static void CommandTopExecuted()
        {
            foreach (var item in observableList)
            {
                item.OnCommandTopEvent();
            }
        }

        public static void CommandExitExecuted()
        {
            foreach (var item in observableList)
            {
                item.OnCommandExitEvent();
            }
        }

        public static void CommmandGuessNumberExecuted(int guessNumber)
        {
            foreach (var item in observableList)
            {
                item.OnCommmandGuessNumberEvent(guessNumber);
            }
        }
    }
}
