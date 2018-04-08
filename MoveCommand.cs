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

        public override void Execute(Tank tank)
        {
            tank.Move(command);
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
                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();
        }
    }
}
