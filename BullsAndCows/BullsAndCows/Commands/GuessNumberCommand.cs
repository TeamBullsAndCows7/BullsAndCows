﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Commands
{
    class GuessNumberCommand : ICommand
    {
        public CommandType Type
        {
            get { return CommandType.Top; }
        }

        public void Execute()
        {
            //check number     
        }
    }
}