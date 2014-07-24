namespace BullsAndCows.Commands
{
    using System;
    using BullsAndCows.Utils;

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
                        if (ValidNumberChecker.IsValidBullsAndCowsNumber(input))
                        {
                            //int userNumber;
                            //if (int.TryParse(input, out userNumber))
                            //{
                            //    command = new GuessNumberCommand(input);
                            //    break;
                            //}
                            //else
                            //{
                            //    throw new ArgumentException("Wrong command, please try again.");
                            //}   

                            command = new GuessNumberCommand(input);
                            break;
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
