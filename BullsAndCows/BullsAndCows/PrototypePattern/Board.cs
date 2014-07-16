namespace BullsAndCows.PrototypePattern
{
    using System;
    using System.Collections.Generic;

    public class Board
    {
        private Dictionary<string, ICloneable> _scoreInstance = new Dictionary<string, ICloneable>();

        public void AddScore(string key, ICloneable scorePrototype)
        {
            _scoreInstance.Add(key, scorePrototype);
        }

        public object GetScore(string key)
        {
            var score = _scoreInstance[key];
            return score.Clone();
        }
    }
}
