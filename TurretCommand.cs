using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class TurretCommand : Command
    {
        public enum Commands
        {
            Rotate90CW,
            Rotate90CCW,
            Up,
            Down,
            None
        }

        public Commands command;

        public TurretCommand(Commands command)
        {
            this.command = command;
        }

        public override void Execute(Tank robot)
        {
            robot.RotateTurret(command);
        }
    }
}
