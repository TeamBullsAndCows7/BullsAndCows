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
    }
}
