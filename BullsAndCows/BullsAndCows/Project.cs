namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //pochvam da pi6a na c#,egati kEfa!
    public class Proekt
    {
        static char[] cheatNumber = { 'X', 'X', 'X', 'X' };

        static Dictionary<string, int> topScoreBoard = new Dictionary<string, int>();

        static int lastPlayerScore = int.MinValue;
        static List<KeyValuePair<string, int>> sortedDict = new List<KeyValuePair<string, int>>();

        //this will be hidden in the Facade and removed from here
        static int SortDictionary(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            return a.Value.CompareTo(b.Value);
        }
        //this will be hidden in the Facade and removed from here
        //start from this method for Decoration pattern usage
        static void StartGame()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.");
            Console.WriteLine("Use 'top' to view the top scoreboard, 'restart' to start a new game and 'help' " +
                              "to cheat and 'exit' to quit the game.");
        }
        //this will be hidden in the Facade and removed from here
        static bool CheckIfNumConsistsOnlyOfDigits(string num)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (Char.IsDigit(num[i]))
                {
                    count++;
                }
            }
            if (count == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //here was GenerateRandomSecretNumber 

        //this will be hidden in the Facade and removed from here
        static void CalculateBullsAndCows(string secretNumber, string guessNumber, ref int bulls, ref int cows)
        {
            List<int> bullIndexes = new List<int>();
            List<int> cowIndexes = new List<int>();
            for (int i = 0; i < secretNumber.Length; i++)
            {
                if (guessNumber[i].Equals(secretNumber[i]))
                {
                    bullIndexes.Add(i);

                    bulls++;

                    ObserverPattern.Observer.BullRevealedEvent();
                }
            }

            for (int i = 0; i < guessNumber.Length; i++)
            {
                for (int index = 0; index < secretNumber.Length; index++)
                {
                    if ((i != index) && !bullIndexes.Contains(index) && !cowIndexes.Contains(index) && !bullIndexes.Contains(i))
                    {
                        if (guessNumber[i].Equals(secretNumber[index]))
                        {
                            cowIndexes.Add(index);
                            cows++;
                            ObserverPattern.Observer.CowRevealedEvent();
                            break;
                        }
                    }
                }
            }
        }

        //this will be hidden in the Facade and removed from here
        static char[] RevealNumberAtRandomPosition(string secretnumber, char[] cheatNumber)
        {
            while (true)
            {
                Random rand = new Random();
                int index = rand.Next(0, 4);
                if (cheatNumber[index] == 'X')
                {
                    cheatNumber[index] = secretnumber[index];
                    return cheatNumber;
                }
                else
                {
                    continue;
                }
            }
        }

        //Memento design(observation) pattern for posible usage
        static void EnterScoreBoard(int score)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string name = Console.ReadLine();
            topScoreBoard.Add(name, score);

            if (score > lastPlayerScore)
            {
                lastPlayerScore = score;
            }

            if (topScoreBoard.Count > 5)
            {
                foreach (KeyValuePair<string, int> player in topScoreBoard)
                {
                    if (player.Value == lastPlayerScore)
                    {
                        topScoreBoard.Remove(player.Key);
                        break;
                    }
                }
            }
            SortAndPrintScoreBoard();
        }
        //Memento design(behavioral) pattern possible usage
        static void SortAndPrintScoreBoard()
        {
            foreach (var pair in topScoreBoard)
            {
                sortedDict.Add(new KeyValuePair<string, int>(pair.Key, pair.Value));
            }

            sortedDict.Sort(SortDictionary);
            Console.WriteLine("Scoreboard: ");
            int counter = 0;
            foreach (KeyValuePair<string, int> player in sortedDict)
            {
                counter++;
                Console.WriteLine("{0}. {1} --> {2} guesses", counter, player.Key, player.Value);
            }
            sortedDict.Clear();
        }

        static void Main()
        {
            StartGame();
            //adding the instance through Singleton
            var attach = RandomNumberGenerator.Instance;
            var secretNumber = attach.Next();
            //string secretNumber = GenerateRandomSecretNumber();            
            string playerInput = null;
            int attempts = 0;
            int cheats = 0;
            //adding instance of Prototype ScoreBoard
            var getScores = new Board();




            while (true)
            {
                Console.Write("Enter your guess or command: ");
                playerInput = Console.ReadLine();

                //helps has bug response by continuing a new game
                //the bug is displayed from the old code 
                //before implementation of Singleton change instance
                //also could possibly throw Message that Player used all numbers of help
                //check number of help used (if-else) or kind of switch
                if (playerInput == "help")
                {
                    char[] revealedDigits = RevealNumberAtRandomPosition(secretNumber.ToString(), cheatNumber);
                    StringBuilder revealedNumber = new StringBuilder();

                    for (int i = 0; i < 4; i++)
                    {
                        revealedNumber.Append(revealedDigits[i]);
                    }
                    Console.WriteLine("The number looks like {0}", revealedNumber.ToString());

                    cheats++;
                    continue;
                }
                else if (playerInput == "restart")
                {
                    Console.WriteLine();
                    StartGame();
                    attempts = 0;
                    secretNumber = attach.Next();
                    continue;
                }
                else if (playerInput == "top")
                {
                    if (topScoreBoard.Count == 0)
                    {
                        Console.WriteLine("Top scoreboard is empty.");
                    }
                    else
                    {
                        SortAndPrintScoreBoard();
                    }
                    continue;
                }
                else if (playerInput == "exit")
                {
                    Console.WriteLine("Good bye!");
                    break;
                }
                else if (playerInput.Length != 4 || CheckIfNumConsistsOnlyOfDigits(playerInput) == false)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }
                attempts++;
                int bulls = 0;
                int cows = 0;
                CalculateBullsAndCows(secretNumber.ToString(), playerInput, ref bulls, ref cows);
                if (playerInput == secretNumber.ToString())
                {
                    if (cheats > 0)
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", attempts, cheats);
                        Console.WriteLine("You are not allowed to enter the top scoreboard.");
                        SortAndPrintScoreBoard();
                        Console.WriteLine();
                        StartGame();
                        attempts = 0;
                        cheats = 0;
                        secretNumber = attach.Next();
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attempts);
                        EnterScoreBoard(attempts);
                        //testing Prototype 
                        //should replace cheats with real scores
                        getScores.AddScore(playerInput, new ScoreBoard(playerInput, cheats));
                        var copiedScores = (ScoreBoard)getScores.GetScore(playerInput);
                        copiedScores.Name = playerInput;
                        copiedScores.Score = cheats;
                        Console.WriteLine(String.Format("Scores: {0} | Cheats: {1}", copiedScores.Name, copiedScores.Score));
                        attempts = 0;
                        Console.WriteLine();
                        StartGame();
                        secretNumber = attach.Next();
                    }
                    continue;
                }
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}