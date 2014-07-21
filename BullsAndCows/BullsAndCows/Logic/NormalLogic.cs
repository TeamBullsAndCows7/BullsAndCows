namespace BullsAndCows.Logic
{
    using BullsAndCows.Utils;
    using System;

    class NormalLogic : ILogic
    {
        private RandomNumberGenerator randomNumberGenerator;
        private ScoreBoard scoreBoard;

        private int helpCalled;
        private int attemptsToGuess;
        private int secretNumber;

        public NormalLogic()
        {
            this.randomNumberGenerator = RandomNumberGenerator.Instance;
            this.scoreBoard = new ScoreBoard();

            this.helpCalled = 0;
            this.attemptsToGuess = 0;
            this.secretNumber = this.randomNumberGenerator.Next();
        }

        public bool Run
        {
            get { throw new NotImplementedException(); }
        }

        public void OnCommandHelpEvent()
        {
            Observer.Observer.CommandHelpEventExecuted();
        }

        public void OnCommandRestartEvent()
        {
            Observer.Observer.CommandRestartEventExecuted();
        }

        public void OnCommandTopEvent()
        {
            Observer.Observer.CommandTopEventExecuted();
        }

        public void OnCommandExitEvent()
        {
            Observer.Observer.CommandExitEventExecuted();
        }

        public void OnCommmandGuessNumberEvent()
        {
            Observer.Observer.CommmandGuessNumberEventExecuted();
        }
    }
}
