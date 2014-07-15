using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public abstract class ScorePrototype
    {
        //could add check for errors in setters
        public string Name { get; set; } //if Name.length = null throw Message
        public int Score { get; set; } //Score < 0 

        public ScorePrototype(int score)
        {

            Score = score;
        }

        public abstract ScorePrototype Clone();
    }
}
