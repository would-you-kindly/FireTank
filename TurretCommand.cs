using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class TurretCommand : Command
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

        public override void Execute(Tank tank)
        {
            tank.RotateTurret(command);
        }

        public override string ToString()
        {
            switch (command)
            {
                case Commands.Rotate90CW:
                    return "Rotate 90 CW";
                case Commands.Rotate90CCW:
                    return "Rotate 90 CCW";
                case Commands.Up:
                    return "Up";
                case Commands.Down:
                    return "Down";
                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();
        }
    }
}
