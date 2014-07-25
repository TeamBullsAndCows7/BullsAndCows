namespace BullsAndCows.Logic
{
    using BullsAndCows.Messenger;
    using BullsAndCows.Utils;
    using System;
    using System.Collections.Generic;

    class NormalLogic : ILogic
    {
        private RandomNumberGenerator randomNumberGenerator;
        private ScoreBoard scoreBoard;
        private ColoredMessenger messanger;
        
        private int helpCalled;
        private int attemptsToGuess;
        private int secretNumber;

        private bool run;
        private char[] hintNumber;  

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
            this.messanger = new ColoredMessenger(new DefaultMessenger());

            this.ResetGameVariables();
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
            this.messanger.ShowRevealNumberMessage(revieldNumber);
        }

        public void OnCommandRestartEvent()
        {
            this.ResetGameVariables();
        }

        public void OnCommandTopEvent()
        {
            this.messanger.ShowTopScoreBoardMessage(this.scoreBoard.ToString());
        }

        public void OnCommandExitEvent()
        {
            this.messanger.ShowExitMessage();
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
                    this.messanger.ShowWinGameMessage(this.attemptsToGuess, this.helpCalled);
                }
                else
                {
                    this.messanger.ShowWinGameMessage(this.attemptsToGuess);

                    this.messanger.ShowEnterYourNameMessage();

                    string player = Console.ReadLine();

                    if (this.scoreBoard.HasToSaveScore(this.attemptsToGuess))
                    {
                        this.scoreBoard.Enter(this.attemptsToGuess, player);
                    }
                    
                    this.messanger.ShowTopScoreBoardMessage(this.scoreBoard.ToString());
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
                        if ((i != j) && 
                            !bullIndexes.Contains(j) && 
                            !cowIndexes.Contains(j) && 
                            !bullIndexes.Contains(i))
                        {
                            if (guessNumberToString[i].Equals(secretNumberToString[j]))
                            {
                                cowIndexes.Add(j);
                                break;
                            }
                        }
                    }
                }

                this.messanger.ShowWrongGuessMessage(bullIndexes.Count, cowIndexes.Count);
            }
        }
    }
}
