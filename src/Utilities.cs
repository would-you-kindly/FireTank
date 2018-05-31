using SFML.Graphics;
using SFML.System;
using System;

namespace FireSafety
{
    public class Utilities
    {
        private static Utilities instance;

        public int TILE_SIZE;
        public int TANKS_COUNT;
        public uint WIDTH_TILE_COUNT;
        public uint HEIGHT_TILE_COUNT;
        public int INIT_BURNING_TREES;
        public int MAX_TANKS_COUNT;

        private Utilities()
        {
            TILE_SIZE = 32;
            TANKS_COUNT = 2;
            WIDTH_TILE_COUNT = 16;
            HEIGHT_TILE_COUNT = 16;
            INIT_BURNING_TREES = 0;
            MAX_TANKS_COUNT = 6;
        }

        public static Utilities GetInstance()
        {
            if (instance == null)
            {
                instance = new Utilities();
            }

            return instance;
        }

        public static void CenterOrigin(Sprite sprite)
        {
            FloatRect rect = sprite.GetLocalBounds();
            sprite.Origin = new Vector2f(rect.Width / 2.0f, rect.Height / 2.0f);
        }

        public static void CenterOrigin(Text text)
        {
            FloatRect rect = text.GetLocalBounds();
            text.Origin = new Vector2f(rect.Width / 2.0f, rect.Height / 2.0f);
        }

        public static void CenterOrigin(Shape shape, float shiftX = 0.0f, float shiftY = 0.0f)
        {
            FloatRect rect = shape.GetLocalBounds();
            shape.Origin = new Vector2f(rect.Width / 2.0f + shiftX, rect.Height / 2.0f + shiftY);
        }

        public static MoveCommand.Commands ToMoveCommand(string value)
        {
            if (value == Properties.Resources.MoveCommandForward)
                return MoveCommand.Commands.Forward;
            if (value == Properties.Resources.MoveCommandBackward)
                return MoveCommand.Commands.Backward;
            if (value == Properties.Resources.MoveCommandRotate45CW)
                return MoveCommand.Commands.Rotate45CW;
            if (value == Properties.Resources.MoveCommandRotate45CCW)
                return MoveCommand.Commands.Rotate45CCW;
            if (value == Properties.Resources.MoveCommandRotate90CW)
                return MoveCommand.Commands.Rotate90CW;
            if (value == Properties.Resources.MoveCommandRotate90CCW)
                return MoveCommand.Commands.Rotate90CCW;
            if (value == Properties.Resources.MoveCommandForwardRotate45CW)
                return MoveCommand.Commands.Forward45CW;
            if (value == Properties.Resources.MoveCommandForwardRotate45CCW)
                return MoveCommand.Commands.Forward45CCW;
            if (value == Properties.Resources.MoveCommandBackwardRotate45CW)
                return MoveCommand.Commands.Backward45CW;
            if (value == Properties.Resources.MoveCommandBackwardRotate45CCW)
                return MoveCommand.Commands.Backward45CCW;
            if (value == Properties.Resources.MoveCommandNone)
                return MoveCommand.Commands.None;

            throw new Exception($"Строкового представления {value} в перечислении MoveCommand.Commands не существует.");
        }

        public static ChargeCommand.Commands ToChargeCommand(string value)
        {
            if (value == Properties.Resources.ChargeCommandPressure1)
                return ChargeCommand.Commands.PressureX1;
            if (value == Properties.Resources.ChargeCommandPressure2)
                return ChargeCommand.Commands.PressureX2;
            if (value == Properties.Resources.ChargeCommandCharge)
                return ChargeCommand.Commands.Charge;
            if (value == Properties.Resources.ChargeCommandRefuel)
                return ChargeCommand.Commands.Refuel;
            if (value == Properties.Resources.ChargeCommandNone)
                return ChargeCommand.Commands.None;

            throw new Exception($"Строкового представления {value} в перечислении ChargeCommand.Commands не существует.");
        }

        public static TurretCommand.Commands ToTurretCommand(string value)
        {
            if (value == Properties.Resources.TurretCommandRotate45CW)
                return TurretCommand.Commands.Rotate45CW;
            if (value == Properties.Resources.TurretCommandRotate45CCW)
                return TurretCommand.Commands.Rotate45CCW;
            if (value == Properties.Resources.TurretCommandRotate90CW)
                return TurretCommand.Commands.Rotate90CW;
            if (value == Properties.Resources.TurretCommandRotate90CCW)
                return TurretCommand.Commands.Rotate90CCW;
            if (value == Properties.Resources.TurretCommandUp)
                return TurretCommand.Commands.Up;
            if (value == Properties.Resources.TurretCommandDown)
                return TurretCommand.Commands.Down;
            if (value == Properties.Resources.TurretCommandShoot)
                return TurretCommand.Commands.Shoot;
            if (value == Properties.Resources.TurretCommandNone)
                return TurretCommand.Commands.None;

            throw new Exception($"Строкового представления {value} в перечислении TurretCommand.Commands не существует.");
        }

        public static string ToMoveString(MoveCommand.Commands value)
        {
            switch (value)
            {
                case MoveCommand.Commands.Forward:
                    return Properties.Resources.MoveCommandForward;
                case MoveCommand.Commands.Backward:
                    return Properties.Resources.MoveCommandBackward;
                case MoveCommand.Commands.Rotate45CW:
                    return Properties.Resources.MoveCommandRotate45CW;
                case MoveCommand.Commands.Rotate45CCW:
                    return Properties.Resources.MoveCommandRotate45CCW;
                case MoveCommand.Commands.Rotate90CW:
                    return Properties.Resources.MoveCommandRotate90CW;
                case MoveCommand.Commands.Rotate90CCW:
                    return Properties.Resources.MoveCommandRotate90CCW;
                case MoveCommand.Commands.Forward45CW:
                    return Properties.Resources.MoveCommandForwardRotate45CW;
                case MoveCommand.Commands.Forward45CCW:
                    return Properties.Resources.MoveCommandForwardRotate45CCW;
                case MoveCommand.Commands.Backward45CW:
                    return Properties.Resources.MoveCommandBackwardRotate45CW;
                case MoveCommand.Commands.Backward45CCW:
                    return Properties.Resources.MoveCommandBackwardRotate45CCW;
                case MoveCommand.Commands.None:
                    return Properties.Resources.MoveCommandNone;
            }

            throw new Exception($"Строкового представления {value} в перечислении MoveCommand.Commands не существует.");
        }

        public static string ToChargeString(ChargeCommand.Commands value)
        {
            switch (value)
            {
                case ChargeCommand.Commands.PressureX1:
                    return Properties.Resources.ChargeCommandPressure1;
                case ChargeCommand.Commands.PressureX2:
                    return Properties.Resources.ChargeCommandPressure2;
                case ChargeCommand.Commands.Charge:
                    return Properties.Resources.ChargeCommandCharge;
                case ChargeCommand.Commands.Refuel:
                    return Properties.Resources.ChargeCommandRefuel;
                case ChargeCommand.Commands.None:
                    return Properties.Resources.ChargeCommandNone;
            }

            throw new Exception($"Строкового представления {value} в перечислении ChargeCommand.Commands не существует.");
        }

        public static string ToTurretString(TurretCommand.Commands value)
        {
            switch (value)
            {
                case TurretCommand.Commands.Rotate45CW:
                    return Properties.Resources.TurretCommandRotate45CW;
                case TurretCommand.Commands.Rotate45CCW:
                    return Properties.Resources.TurretCommandRotate45CCW;
                case TurretCommand.Commands.Rotate90CW:
                    return Properties.Resources.TurretCommandRotate90CW;
                case TurretCommand.Commands.Rotate90CCW:
                    return Properties.Resources.TurretCommandRotate90CCW;
                case TurretCommand.Commands.Up:
                    return Properties.Resources.TurretCommandUp;
                case TurretCommand.Commands.Down:
                    return Properties.Resources.TurretCommandDown;
                case TurretCommand.Commands.Shoot:
                    return Properties.Resources.TurretCommandShoot;
                case TurretCommand.Commands.None:
                    return Properties.Resources.TurretCommandNone;
            }

            throw new Exception($"Строкового представления {value} в перечислении TurretCommand.Commands не существует.");
        }

        public static float NormalizedRotation(float rotation)
        {
            while (rotation < 0)
            {
                rotation += 360;
            }
            while (rotation >= 360)
            {
                rotation -= 360;
            }

            return rotation;
        }
    }
}
