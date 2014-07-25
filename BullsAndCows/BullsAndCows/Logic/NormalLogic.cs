namespace BullsAndCows.Logic
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
        private int secretNumber;

        private bool run;
        private char[] hintNumber;
        private static Messenger.DefaultMessenger messanger = new Messenger.DefaultMessenger();
        private Messenger.ColoredMessenger message = new Messenger.ColoredMessenger(messanger);

        private void ResetGameVariables()
        {
            this.helpCalled = 0;
            this.attemptsToGuess = 0;
            this.secretNumber = this.randomNumberGenerator.Next();
            this.hintNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.run = true;
        }

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
            string secretNumberToString = this.secretNumber.ToString();

            helpCalled++;

            while (helpCalled <= 4)
            {
                Random rand = new Random();
                int index = rand.Next(0, 4);

                if (this.hintNumber[index] == 'X')
                {
                    this.hintNumber[index] = secretNumberToString[index];
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
            ResetGameVariables();
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

        public void OnCommmandGuessNumberEvent(int guessNumber)
        {
            List<int> bullIndexes = new List<int>();
            List<int> cowIndexes = new List<int>();
            string guessNumberToString = guessNumber.ToString();
            string secretNumberToString = this.secretNumber.ToString();

            this.attemptsToGuess++;

            if (guessNumberToString.Equals(secretNumberToString))
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
                for (int i = 0; i < secretNumberToString.Length; i++)
                {
                    if (guessNumberToString[i].Equals(secretNumberToString[i]))
                    {
                        bullIndexes.Add(i);
                        //bulls++;
                    }
                }

                for (int i = 0; i < guessNumberToString.Length; i++)
                {
                    for (int j = 0; j < secretNumberToString.Length; j++)
                    {
                        if ((i != j) && !bullIndexes.Contains(j) && !cowIndexes.Contains(j) && !bullIndexes.Contains(i))
                        {
                            if (guessNumberToString[i].Equals(secretNumberToString[j]))
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
