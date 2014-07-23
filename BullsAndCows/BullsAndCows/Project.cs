namespace BullsAndCows
{
    using BullsAndCows.Utils;
    using BullsAndCows.Driver;
    //original project code
    using System;
    using System.Collections.Generic;
    using System.Text;

    //pochvam da pi6a na c#,egati kEfa!
    public class Proekt
    {
        /*
         * 
        static char[] cheatNumber = { 'X', 'X', 'X', 'X' };
        static SortedDictionary<string, int> ScoreBoard = new SortedDictionary<string, int>();     

        static void StartGame()
        {
            Console.WriteLine("Welcome to “Bulls and Cows” game.\nPlease try to guess my secret 4-digit number.\n\n");
            Console.WriteLine("Use one of the following command: ");
            Console.WriteLine("\r'top' - view the top scoreboard.");
            Console.WriteLine("\r'restart' - start a new game.");
            Console.WriteLine("\r'help' - reveal a number.");
            Console.WriteLine("\r'exit' - quit the game.");
        }

        static bool IsCorrectNumber(string num)
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
                            break;
                        }
                    }
                }
            }
        }

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
         */

        static void Main()
        {
            IDriver driver = new Driver.Driver();
            driver.Start();
            /*
            StartGame();

            string secretNumber = RandomNumberGenerator.Instance.Next().ToString();
            string userInput = null;
            int attemptsToGuess = 0;
            int helpCalled = 0;

            while (true)
            {
                Console.Write("Enter your guess or command: ");
                userInput = Console.ReadLine();

                if (userInput == "help")
                {
                    char[] revealedDigits = RevealNumberAtRandomPosition(secretNumber, cheatNumber);
                    StringBuilder revealedNumber = new StringBuilder();
                    for (int i = 0; i < 4; i++)
                    {
                        revealedNumber.Append(revealedDigits[i]);
                    }
                    Console.WriteLine("The number looks like {0}", revealedNumber.ToString());
                    helpCalled++;
                    continue;
                }
                else if (userInput == "restart")
                {
                    Console.WriteLine();
                    StartGame();
                    attemptsToGuess = 0;
                    secretNumber = RandomNumberGenerator.Instance.Next().ToString();
                    continue;
                }
                else if (userInput == "top")
                {
                    if (ScoreBoard.Count == 0)
                    {
                        Console.WriteLine("Top scoreboard is empty.");
                    }
                    else
                    {
                        //PrintScoreBoard();
                    }
                    continue;
                }
                else if (userInput == "exit")
                {
                    Console.WriteLine("Good bye!");
                    break;
                }
                else if (userInput.Length != 4 || IsCorrectNumber(userInput) == false)
                {
                    Console.WriteLine("Incorrect guess or command!");
                    continue;
                }

                attemptsToGuess++;
                int bulls = 0;
                int cows = 0;
                CalculateBullsAndCows(secretNumber, userInput, ref bulls, ref cows);
                if (userInput == secretNumber)
                {
                    if (helpCalled > 0)
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts and {1} cheats.", attemptsToGuess, helpCalled);
                        Console.WriteLine("You are not allowed to enter the top scoreboard.");
                        //PrintScoreBoard();
                        Console.WriteLine();
                        StartGame();
                        attemptsToGuess = 0;
                        helpCalled = 0;
                        secretNumber = RandomNumberGenerator.Instance.Next().ToString();
                    }
                    else
                    {
                        Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", attemptsToGuess);
                        //EnterScoreBoard(attemptsToGuess);
                        attemptsToGuess = 0;
                        Console.WriteLine();
                        StartGame();
                        secretNumber = RandomNumberGenerator.Instance.Next().ToString();
                    }
                    continue;
                }
                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bulls, cows);
            }
             */
        }
    }
}