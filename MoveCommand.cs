using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class MoveCommand : Command
    {
        public enum Commands
        {
            Forward,
            Backward,
            Rotate90CW,
            Rotate90CCW,
            Rotate45CW,
            Rotate45CCW,
            None
        }

        public Commands command;

        public MoveCommand(Commands command)
        {
            this.command = command;
        }

        public override void Execute(Tank robot)
        {
            robot.Move(command);
        }
    }
}
