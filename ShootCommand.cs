using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class ShootCommand : Command
    {
        public enum Commands
        {
            IncreaseWaterPressure,
            Shoot,
            None
        }

        public Commands command;

        public ShootCommand(Commands command)
        {
            this.command = command;
        }

        public override void Execute(Tank robot)
        {
            robot.Shoot(command);
        }
    }
}
