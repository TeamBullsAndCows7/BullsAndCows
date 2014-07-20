using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Commands
{
    public static class CommandFactory
    {
        public static ICommand Create(string input)
        {
            ICommand command = null;

            switch (input)
            {
                case "help":
                    {
                        command = new HelpCommand();
                        break;
                    }
                case "top":
                    {
                        command = new TopCommand();
                        break;
                    }
                case "restart":
                    {
                        command = new RestartCommand();
                        break;
                    }
                case "exit":
                    {
                        command = new ExitCommand();
                        break;
                    }
                default:
                    {
                        if (input.Length == 4)
                        {
                            int userNumber;
                            if (int.TryParse(input, out userNumber))
                            {
                                command = new GuessNumberCommand();
                                break;
                            }
                            else
                            {
                                throw new ArgumentException("Wrong command, please try again.");
                            }   
                        }
                        else
                        {
                            throw new ArgumentException("Wrong number, please try again.");
                        } 
                    }      
            }

            return command;
        }
    }
}
