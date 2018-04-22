using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class MoveCommand : Command
    {
        public enum Commands
        {
            Forward,
            Backward,
            Forward45CW,
            Forward45CCW,
            Backward45CW,
            Backward45CCW,
            Rotate45CW,
            Rotate45CCW,
            Rotate90CW,
            Rotate90CCW,
            None
        }

        public Commands command;

        public MoveCommand(Commands command)
        {
            this.command = command;
        }

        public override void Execute(Tank tank)
        {
            tank.MovementCommand(command);
        }

        public override string ToString()
        {
            switch (command)
            {
                case Commands.Forward:
                    return "Forward";
                case Commands.Backward:
                    return "Backward";
                case Commands.Rotate90CW:
                    return "Rotate 90 CW";
                case Commands.Rotate90CCW:
                    return "Rotate 90 CCW";
                case Commands.Rotate45CW:
                    return "Rotate 45 CW";
                case Commands.Rotate45CCW:
                    return "Rotate 45 CCW";
                case Commands.Forward45CW:
                    return "Forward 45 CW";
                case Commands.Forward45CCW:
                    return "Forward 45 CCW";
                case Commands.Backward45CW:
                    return "Backward 45 CW";
                case Commands.Backward45CCW:
                    return "Backward 45 CCW";
                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();
        }
    }
}
