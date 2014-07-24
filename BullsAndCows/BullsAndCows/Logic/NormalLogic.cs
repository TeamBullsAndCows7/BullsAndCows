﻿namespace BullsAndCows.Logic
{
    using BullsAndCows.Utils;
    using System;
    using System.Collections.Generic;

    class NormalLogic : ILogic
    {
        private RandomNumberGenerator randomNumberGenerator;
        private ScoreBoard scoreBoard;

        private int helpCalled;
        private int attemptsToGuess;
        private string secretNumber;

        private bool run;
        private char[] hintNumber;
        private static Messenger.DefaultMessenger messanger = new Messenger.DefaultMessenger();
        private Messenger.ColoredMessenger message = new Messenger.ColoredMessenger(messanger);

        public NormalLogic()
        {
            this.randomNumberGenerator = RandomNumberGenerator.Instance;
            this.scoreBoard = new ScoreBoard();

            ResetGameVariables();
        }

        public bool Run
        {
            get
            {
                return this.run;
            }
        }

        public void OnCommandHelpEvent()
        {
            //throw new NotImplementedException();
            //string secretNumberToString = this.secretNumber;

            helpCalled++;

            while (helpCalled <= 4)
            {
                // TODO - use RandomNumberGenerator
                Random rand = new Random();
                int index = rand.Next(0, 4);

                if (this.hintNumber[index] == 'X')
                {
                    this.hintNumber[index] = secretNumber[index];
                    break;
                }
                else
                {
                    continue;
                }
            }

            string revieldNumber = new string(this.hintNumber);
            //Console.WriteLine("The number looks like {0}", revieldNumber);
            message.ShowRevealNumberMessage(revieldNumber);
        }

        public void OnCommandRestartEvent()
        {
            //throw new NotImplementedException();

            //this.randomNumberGenerator = RandomNumberGenerator.Instance;
            //this.scoreBoard = new ScoreBoard();

            ResetGameVariables();
        }

        private void ResetGameVariables()
        {
            this.helpCalled = 0;
            this.attemptsToGuess = 0;
            this.secretNumber = this.randomNumberGenerator.Next();
            this.hintNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.run = true;

            Console.WriteLine(this.secretNumber); // TODO - remove in final version
        }

        public void OnCommandTopEvent()
        {
            //throw new NotImplementedException();

            //this.scoreBoard.ToString();
            message.Messenger.ShowTopScoreBoardMessage(this.scoreBoard.ToString());
        }

        public void OnCommandExitEvent()
        {
            //throw new NotImplementedException();

            //Console.WriteLine("Good bye!");
            message.ShowExitMessage();
            this.run = false;
        }

        public void OnCommmandGuessNumberEvent(string guessNumber)
        {
            List<int> bullIndexes = new List<int>();
            List<int> cowIndexes = new List<int>();
            //string guessNumberToString = guessNumber.ToString();
            //string secretNumberToString = this.secretNumber;

            this.attemptsToGuess++;

            if (guessNumber.Equals(this.secretNumber))
            {
                //message.ShowWinGameMessage();
                if (this.helpCalled > 0)
                {
                    //Console.WriteLine("You called for help {1} time(s) and you are not allowed to enter the top scoreboard.", this.helpCalled);
                    message.Messenger.ShowWinGameMessage(this.attemptsToGuess, this.helpCalled);
                }
                else
                {
                    //Console.WriteLine("Congratulations! You guessed the secret number in {0} attempts.", this.attemptsToGuess);
                    message.Messenger.ShowWinGameMessage(this.attemptsToGuess);

                    //Console.Write("Please enter your name for the top scoreboard: ");
                    message.Messenger.ShowEnterYourNameMessage();

                    string player = Console.ReadLine();

                    this.scoreBoard.Enter(this.attemptsToGuess, player);
                    message.Messenger.ShowTopScoreBoardMessage(this.scoreBoard.ToString());
                }

                // restart the game - TODO - probably is not a good idea to be here...
                ResetGameVariables();
            }
            else
            {
                for (int i = 0; i < this.secretNumber.Length; i++)
                {
                    if (guessNumber[i].Equals(this.secretNumber[i]))
                    {
                        bullIndexes.Add(i);
                        //bulls++;
                    }
                }

                for (int i = 0; i < guessNumber.Length; i++)
                {
                    for (int j = 0; j < this.secretNumber.Length; j++)
                    {
                        if ((i != j) && !bullIndexes.Contains(j) && !cowIndexes.Contains(j) && !bullIndexes.Contains(i))
                        {
                            if (guessNumber[i].Equals(this.secretNumber[j]))
                            {
                                cowIndexes.Add(j);
                                //cows++;
                                break;
                            }
                        }
                    }
                }

                //Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullIndexes.Count, cowIndexes.Count);
                message.Messenger.ShowWrongGuessMessage(bullIndexes.Count, cowIndexes.Count);
            }

            //throw new NotImplementedException();
        }
    }
}
