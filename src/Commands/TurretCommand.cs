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
                    return "45° по ч.с.";
                case Commands.Rotate45CCW:
                    return "45° пр. ч.с.";
                case Commands.Rotate90CW:
                    return "90° по ч.с.";
                case Commands.Rotate90CCW:
                    return "90° пр. ч.с.";
                case Commands.Up:
                    return "Поднять";
                case Commands.Down:
                    return "Опустить";
                case Commands.Shoot:
                    return "Выстрелить";
                case Commands.None:
                    return "Бездействие";
            }

            throw new Exception("Неверно задано название команды TurretCommand.");
        }
    }
}
