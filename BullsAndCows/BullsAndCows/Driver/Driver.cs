namespace BullsAndCows.Driver
{
    using BullsAndCows.Commands;
    using BullsAndCows.Logic;
    using BullsAndCows.Messenger;
    using BullsAndCows.Observer;
    using System;

    public class Driver : IDriver
    {
        private ILogic gameLogic;
        private ColoredMessenger messanger;

        public Driver()
        {
            this.gameLogic = new NormalLogic();
            this.messanger = new ColoredMessenger(new DefaultMessenger());           
        }

        public void Start()
        {
            Observer.Attach(this.gameLogic);
            this.messanger.ShowStartGameMessage();

            while (this.gameLogic.Run)
            {
                this.messanger.ShowRequestInputMessage();
                string userInput = Console.ReadLine();

                try
                {
                    ICommand command = CommandFactory.Create(userInput);
                    command.Execute();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Stop()
        {
            Observer.Dettach(this.gameLogic);
        }

        public void Restart()
        {
            this.Stop();
            this.Start();
        }
    }
}
