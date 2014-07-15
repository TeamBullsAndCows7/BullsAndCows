using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class ScoreBoard : ScorePrototype
    {

        public ScoreBoard(string name, int score)
            : base(score)
        {
        }

        public override ScorePrototype Clone()
        {
            //we should use shallow copy/ if not correct usage
            return (ScorePrototype)this.MemberwiseClone();
        }
    }
}
