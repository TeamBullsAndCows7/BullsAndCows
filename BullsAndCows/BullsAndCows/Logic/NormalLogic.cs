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
        private Messenger.ColoredMessenger messanger = new Messenger.ColoredMessenger(new Messenger.DefaultMessenger());

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
            messanger.ShowRevealNumberMessage(revieldNumber);
        }

        public void OnCommandRestartEvent()
        {
            ResetGameVariables();
        }

        private void ResetGameVariables()
        {
            this.helpCalled = 0;
            this.attemptsToGuess = 0;
            this.secretNumber = this.randomNumberGenerator.Next();
            this.hintNumber = new char[4] { 'X', 'X', 'X', 'X' };
            this.run = true;
        }

        public void OnCommandTopEvent()
        {
            messanger.Messenger.ShowTopScoreBoardMessage(this.scoreBoard.ToString());
        }

        public void OnCommandExitEvent()
        {
            messanger.ShowExitMessage();
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
                if (this.helpCalled > 0)
                {
                    messanger.Messenger.ShowWinGameMessage(this.attemptsToGuess, this.helpCalled);
                }
                else
                {
                    messanger.Messenger.ShowWinGameMessage(this.attemptsToGuess);

                    messanger.Messenger.ShowEnterYourNameMessage();

                    string player = Console.ReadLine();

                    this.scoreBoard.Enter(this.attemptsToGuess, player);
                    messanger.Messenger.ShowTopScoreBoardMessage(this.scoreBoard.ToString());
                }

                ResetGameVariables();
            }
            else
            {
                for (int i = 0; i < secretNumberToString.Length; i++)
                {
                    if (guessNumberToString[i].Equals(secretNumberToString[i]))
                    {
                        bullIndexes.Add(i);
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
                                break;
                            }
                        }
                    }
                }

                messanger.Messenger.ShowWrongGuessMessage(bullIndexes.Count, cowIndexes.Count);
            }
        }
    }
}
