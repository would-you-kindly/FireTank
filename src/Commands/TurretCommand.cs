using System;
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
                    return Properties.Resources.TurretCommandRotate45CW;
                case Commands.Rotate45CCW:
                    return Properties.Resources.TurretCommandRotate45CCW;
                case Commands.Rotate90CW:
                    return Properties.Resources.TurretCommandRotate90CW;
                case Commands.Rotate90CCW:
                    return Properties.Resources.TurretCommandRotate90CCW;
                case Commands.Up:
                    return Properties.Resources.TurretCommandUp;
                case Commands.Down:
                    return Properties.Resources.TurretCommandDown;
                case Commands.Shoot:
                    return Properties.Resources.TurretCommandShoot;
                case Commands.None:
                    return Properties.Resources.TurretCommandNone;
            }

            throw new Exception("Неверно задано название команды TurretCommand.");
        }
    }
}
