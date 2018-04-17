using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class ShootCommand : Command
    {
        public enum Commands
        {
            IncreaseWaterPressure,
            None
        }

        public Commands command { get; set; }

        public ShootCommand()
        {

        }

        public ShootCommand(Commands command)
        {
            this.command = command;
        }

        public override void Execute(Tank tank)
        {
            tank.Shoot(command);
        }

        public override string ToString()
        {
            switch (command)
            {
                case Commands.IncreaseWaterPressure:
                    return "Pressure";

                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();

        }
    }
}
