namespace BullsAndCows.PrototypePattern
{
    using System;
    public class ScoreBoard : ICloneable
    {

        public ScoreBoard(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        // Validation required
        public int Score { get; set; }

        public string Name { get; set; }

        object ICloneable.Clone()
        {
            return this.MemberwiseClone() as ScoreBoard;
        }
    }
}
