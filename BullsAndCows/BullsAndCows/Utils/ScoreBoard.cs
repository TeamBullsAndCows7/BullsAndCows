namespace BullsAndCows.Utils
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ScoreBoard
    {
        private const int MaxScoresNumber = 5;
        private SortedDictionary<int, List<string>> scoresList;

        public ScoreBoard()
        {
            this.scoresList = new SortedDictionary<int, List<string>>();
        }

        public bool HasToSaveScore(int score)
        {
            if (this.scoresList.Count == MaxScoresNumber && this.scoresList.Last().Key < score)
            {
                return false;
            }

            return true;
        }

        public void Enter(int score, string playerName)
        {
            if (this.scoresList.Keys.Contains(score))
            {
                if (!this.scoresList[score].Contains(playerName))
                {
                    this.scoresList[score].Add(playerName);
                }
            }
            else
            {
                this.scoresList.Add(score, new List<string>() { playerName });
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\nTop Score Board:\n");

            if (this.scoresList.Count == 0)
            {
                sb.Append("\n-- Score Board is Empty --\n");
            }
            else
            {
                int rank = 1;
                foreach (var item in this.scoresList)
                {
                    var playerNames = item.Value;
                    foreach (var name in playerNames)
                    {
                        sb.AppendFormat("{0}. {1} --> {2} guesses\n", rank, name, item.Key);
                    }
                    ++rank;
                }
            }

            return sb.ToString();
        }
    }
}
