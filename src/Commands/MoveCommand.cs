using System;
using System.Xml.Serialization;

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

        [XmlElement(Namespace = "MoveCommand")]
        public Commands command;

        public MoveCommand()
        {
        }

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
                    return "Вперед";
                case Commands.Backward:
                    return "Назад";
                case Commands.Rotate90CW:
                    return "90° по ч.с.";
                case Commands.Rotate90CCW:
                    return "90° пр. ч.с.";
                case Commands.Rotate45CW:
                    return "45° по ч.с.";
                case Commands.Rotate45CCW:
                    return "45° пр. ч.с.";
                case Commands.Forward45CW:
                    return "Вперед 45° по ч.с.";
                case Commands.Forward45CCW:
                    return "Вперед 45° пр. ч.с.";
                case Commands.Backward45CW:
                    return "Назад 45° по ч.с.";
                case Commands.Backward45CCW:
                    return "Назад 45° пр. ч.с.";
                case Commands.None:
                    return "Бездействие";
            }

            throw new Exception("Неверно задано название команды MoveCommand.");
        }
    }
}
