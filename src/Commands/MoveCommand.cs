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
            Rotate45CW,
            Rotate45CCW,
            Rotate90CW,
            Rotate90CCW,
            Forward45CW,
            Forward45CCW,
            Backward45CW,
            Backward45CCW,

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
                    return Properties.Resources.MoveCommandForward;
                case Commands.Backward:
                    return Properties.Resources.MoveCommandBackward;
                case Commands.Rotate45CW:
                    return Properties.Resources.MoveCommandRotate45CW;
                case Commands.Rotate45CCW:
                    return Properties.Resources.MoveCommandRotate45CCW;
                case Commands.Rotate90CW:
                    return Properties.Resources.MoveCommandRotate90CW;
                case Commands.Rotate90CCW:
                    return Properties.Resources.MoveCommandRotate90CCW;
                case Commands.Forward45CW:
                    return Properties.Resources.MoveCommandForwardRotate45CW;
                case Commands.Forward45CCW:
                    return Properties.Resources.MoveCommandForwardRotate45CCW;
                case Commands.Backward45CW:
                    return Properties.Resources.MoveCommandBackwardRotate45CW;
                case Commands.Backward45CCW:
                    return Properties.Resources.MoveCommandBackwardRotate45CCW;
                case Commands.None:
                    return Properties.Resources.MoveCommandNone;
            }

            throw new Exception("Неверно задано название команды MoveCommand.");
        }
    }
}
