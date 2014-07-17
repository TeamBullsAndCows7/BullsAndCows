namespace BullsAndCows.ObserverPattern
{
    using System;
    using System.Collections.Generic;

    public static class Observer
    {
        private static List<IObservable> observableList;

        static Observer(int secretNumber)
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

        public static void CowRevealedEvent()
        {
            foreach (var item in observableList)
            {
                item.NotifyCowRevealed();
            }
        }

        public static void BullRevealedEvent()
        {
            foreach (var item in observableList)
            {
                item.NotifyBullRevealed();
            }
        }
    }
}
