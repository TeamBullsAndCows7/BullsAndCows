using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Commands
{
    class GuessNumberCommand : ICommand
    {
        private string guessNumber;

        public GuessNumberCommand(string userNumber)
        {
            this.guessNumber = userNumber;
        } 

        public CommandType Type
        {
            get { return CommandType.GuessNumber; }
        }

        public void Execute()
        {
            Observer.Observer.CommmandGuessNumberExecuted(this.guessNumber);
        }
    }
}
