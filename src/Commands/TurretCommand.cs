using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    public class TurretCommand : Command
    {
        public enum Commands
        {
            Rotate45CW,
            Rotate45CCW,
            Rotate90CW,
            Rotate90CCW,
            Up,
            Down,
            Shoot,

            None
        }

        [XmlElement(Namespace = "TurretCommand")]
        public Commands command;

        public TurretCommand()
        {
        }

        public TurretCommand(Commands command)
        {
            this.command = command;
        }

        public override void Execute(Tank tank)
        {
            tank.TurretCommand(command);
        }

        public override string ToString()
        {
            switch (command)
            {
                case Commands.Rotate45CW:
                    return "Rotate 45 CW";
                case Commands.Rotate45CCW:
                    return "Rotate 45 CCW";
                case Commands.Rotate90CW:
                    return "Rotate 90 CW";
                case Commands.Rotate90CCW:
                    return "Rotate 90 CCW";
                case Commands.Up:
                    return "Up";
                case Commands.Down:
                    return "Down";
                case Commands.Shoot:
                    return "Shoot";
                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();
        }
    }
}
