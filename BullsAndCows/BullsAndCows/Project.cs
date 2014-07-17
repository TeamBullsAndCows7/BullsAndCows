namespace BullsAndCows
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using BullsAndCows.PrototypePattern;
    using BullsAndCows.SingletonPattern;

    //pochvam da pi6a na c#,egati kEfa!
    public class Proekt
    {
        static char[] cheatNumber = { 'X', 'X', 'X', 'X' };

        //introduce Facade field
        static GameEngine gameEngine = GameEngine.GetInstance();
        
        static Dictionary<string, int> topScoreBoard = new Dictionary<string, int>();

        static int lastPlayerScore = int.MinValue;
        static List<KeyValuePair<string, int>> sortedDict = new List<KeyValuePair<string, int>>();

        // here was SortDictionary

        //here was Start Game method

        // here was CheckIfNumConsistsOnlyOfDigits

        // here was GenerateRandomSecretNumber 

        // here was CalculateBullsAndCows

        // here was RevealNumberAtRandomPosition        

        //Memento design(observation) pattern for possible usage

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

            sortedDict.Sort(gameEngine.SortDictionary);
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
            //introducing the Facade Pattern
            gameEngine.StartMessage();

            //StartGame();
            // adding the instance through Singleton
            var attach = RandomNumberGenerator.Instance;
            var secretNumber = attach.NextNumber();
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
                    char[] revealedDigits = gameEngine.RevealNumber(secretNumber.ToString(), cheatNumber);
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
                    gameEngine.StartMessage();
                    //StartGame();
                    attempts = 0;
                    secretNumber = attach.NextNumber();
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
                else if (!gameEngine.CheckIfNumberIsValid(playerInput))
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }
                attempts++;
                int bulls = 0;
                int cows = 0;
                gameEngine.GetBullsAndCows(secretNumber.ToString(), playerInput, ref bulls, ref cows);
                //CalculateBullsAndCows(secretNumber.ToString(), playerInput, ref bulls, ref cows);
                if (playerInput == secretNumber.ToString())
                {
                    if (cheats > 0)
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", attempts, cheats);
                        Console.WriteLine("You are not allowed to enter the top scoreboard.");
                        SortAndPrintScoreBoard();
                        Console.WriteLine();
                        gameEngine.StartMessage();
                        //StartGame();
                        attempts = 0;
                        cheats = 0;
                        secretNumber = attach.NextNumber();
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
                        gameEngine.StartMessage();
                        //StartGame();                        
                        secretNumber = attach.NextNumber();
                    }
                    continue;
                }
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
        }
    }
}