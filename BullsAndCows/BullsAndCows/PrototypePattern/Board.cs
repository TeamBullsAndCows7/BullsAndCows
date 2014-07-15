using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class Board
    {
        private Dictionary<string, ScorePrototype> _scoreInstance = new Dictionary<string, ScorePrototype>();

        public void AddScore(string key, ScorePrototype scorePrototype)
        {
            _scoreInstance.Add(key, scorePrototype);
        }

        public ScorePrototype GetScore(string key)
        {
            var score = _scoreInstance[key];
            return score.Clone();
        }
    }
}
