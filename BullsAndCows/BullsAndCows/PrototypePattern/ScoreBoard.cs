namespace BullsAndCows.PrototypePattern
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
