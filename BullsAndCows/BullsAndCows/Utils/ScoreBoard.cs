namespace BullsAndCows.Utils
{
    using System.Collections.Generic;
    using System.Text;

    public class ScoreBoard
    {
        private const int MaxScoresNumber = 5;
        private SortedDictionary<int, string> scoresList;

        public ScoreBoard()
        {
            this.scoresList = new SortedDictionary<int, string>();
        }

        public void Enter(int score, string player)
        {

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (this.scoresList.Count == 0)
            {
                sb.Append("\n-- Score Board is Empty --\n");
            }
            else
            {
                int rank = 1;
                foreach (var item in this.scoresList)
                {
                    sb.AppendFormat("{0}. {1} --> {2} guesses", rank, item.Key, item.Value);
                    ++rank;
                }
            }

            return sb.ToString();
        }
    }
}
