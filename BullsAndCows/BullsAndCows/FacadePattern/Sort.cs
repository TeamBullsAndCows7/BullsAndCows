namespace BullsAndCows
{
    using System.Collections.Generic;

    public class Sort
    {
        public int SortDictionary(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return a.Value.CompareTo(b.Value);
        }
    }
}
