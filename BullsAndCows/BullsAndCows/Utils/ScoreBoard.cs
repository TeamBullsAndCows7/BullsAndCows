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
            this.scoresList.Add(score, player);

            
            //if (score > lastPlayerScore)
            //{
            //    lastPlayerScore = score;
            //}

            //if (topScoreBoard.Count > 5)
            //{
            //    foreach (KeyValuePair<string, int> player in topScoreBoard)
            //    {
            //        if (player.Value == lastPlayerScore)
            //        {
            //            topScoreBoard.Remove(player.Key);
            //            break;
            //        }
            //    }
            //}
        }

        //public int SortDictionary(KeyValuePair<int, string> a, KeyValuePair<int, string> b)
        //{
        //    return a.Key.CompareTo(b.Key);
        //}

        //public void SortScoreBoard()
        //{
        //    foreach (var pair in topScoreBoard)
        //    {
        //        sortedDict.Add(new KeyValuePair<string, int>(pair.Key, pair.Value));
        //    }

        //    sortedDict.Sort(SortDictionary);
        //    Console.WriteLine("Scoreboard: ");
        //    int counter = 0;

        //    foreach (KeyValuePair<string, int> player in sortedDict)
        //    {
        //        counter++;
        //        Console.WriteLine("{0}. {1} --> {2} guesses", counter, player.Key, player.Value);
        //    }

        //    sortedDict.Clear();
        //}

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
                    // TODO - fix the bug with SortedDictionary - cannot have several player with same score
                    sb.AppendFormat("{0}. {1} --> {2} guesses\n", rank, item.Key, item.Value);
                    ++rank;
                }
            }

            return sb.ToString();
        }
    }
}
