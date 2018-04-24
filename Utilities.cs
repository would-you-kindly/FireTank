using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public static class Utilities
    {
        // TODO: Грузить эти значения из xml
        public static int TILE_SIZE = 32;
        public static int TANKS_COUNT = 2;
        public static uint WIDTH_TILE_COUNT = 16;
        public static uint HEIGHT_TILE_COUNT = 16;
        public static uint WINDOW_WIDTH = (uint)TILE_SIZE * WIDTH_TILE_COUNT;
        public static uint WINDOW_HEIGHT = (uint)TILE_SIZE * HEIGHT_TILE_COUNT;
        public static int MAX_TANKS_COUNT = 4;
        public static int CURRENT_ACTION_NUMBER = 0;

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
            switch (value)
            {
                case "Forward":
                    return MoveCommand.Commands.Forward;
                case "Backward":
                    return MoveCommand.Commands.Backward;
                case "Rotate 90 CW":
                    return MoveCommand.Commands.Rotate90CW;
                case "Rotate 90 CCW":
                    return MoveCommand.Commands.Rotate90CCW;
                case "Rotate 45 CW":
                    return MoveCommand.Commands.Rotate45CW;
                case "Rotate 45 CCW":
                    return MoveCommand.Commands.Rotate45CCW;
                case "Forward 45 CW":
                    return MoveCommand.Commands.Forward45CW;
                case "Forward 45 CCW":
                    return MoveCommand.Commands.Forward45CCW;
                case "Backward 45 CW":
                    return MoveCommand.Commands.Backward45CW;
                case "Backward 45 CCW":
                    return MoveCommand.Commands.Backward45CCW;
                case "None":
                    return MoveCommand.Commands.None;
            }

            throw new Exception($"Строкового представления {value} в перечислении MoveCommand.Commands не существует");
        }

        public static ChargeCommand.Commands ToChargeCommand(string value)
        {
            switch (value)
            {
                case "Pressure":
                    return ChargeCommand.Commands.Pressure;
                case "None":
                    return ChargeCommand.Commands.None;
            }

            throw new Exception($"Строкового представления {value} в перечислении ChargeCommand.Commands не существует");
        }

        public static TurretCommand.Commands ToTurretCommand(string value)
        {
            switch (value)
            {
                case "Rotate 45 CW":
                    return TurretCommand.Commands.Rotate45CW;
                case "Rotate 45 CCW":
                    return TurretCommand.Commands.Rotate45CCW;
                case "Rotate 90 CW":
                    return TurretCommand.Commands.Rotate90CW;
                case "Rotate 90 CCW":
                    return TurretCommand.Commands.Rotate90CCW;
                case "Up":
                    return TurretCommand.Commands.Up;
                case "Down":
                    return TurretCommand.Commands.Down;
                case "Shoot":
                    return TurretCommand.Commands.Shoot;
                case "None":
                    return TurretCommand.Commands.None;
            }

            throw new Exception($"Строкового представления {value} в перечислении TurretCommand.Commands не существует");
        }

        public static string ToMoveString(MoveCommand.Commands value)
        {
            switch (value)
            {
                case MoveCommand.Commands.Forward:
                    return "Forward";
                case MoveCommand.Commands.Backward:
                    return "Backward";
                case MoveCommand.Commands.Rotate90CW:
                    return "Rotate 90 CW";
                case MoveCommand.Commands.Rotate90CCW:
                    return "Rotate 90 CCW";
                case MoveCommand.Commands.Rotate45CW:
                    return "Rotate 45 CW";
                case MoveCommand.Commands.Rotate45CCW:
                    return "Rotate 45 CCW";
                case MoveCommand.Commands.Forward45CW:
                    return "Forward 45 CW";
                case MoveCommand.Commands.Forward45CCW:
                    return "Forward 45 CCW";
                case MoveCommand.Commands.Backward45CW:
                    return "Backward 45 CW";
                case MoveCommand.Commands.Backward45CCW:
                    return "Backward 45 CCW";
                case MoveCommand.Commands.None:
                    return "None";
            }

            throw new Exception($"Строкового представления {value} в перечислении MoveCommand.Commands не существует");
        }

        public static string ToChargeString(ChargeCommand.Commands value)
        {
            switch (value)
            {
                case ChargeCommand.Commands.Pressure:
                    return "Pressure";
                case ChargeCommand.Commands.None:
                    return "None";
            }

            throw new Exception($"Строкового представления {value} в перечислении ChargeCommand.Commands не существует");
        }

        public static string ToTurretString(TurretCommand.Commands value)
        {
            switch (value)
            {
                case TurretCommand.Commands.Rotate45CW:
                    return "Rotate 45 CW";
                case TurretCommand.Commands.Rotate45CCW:
                    return "Rotate 45 CCW";
                case TurretCommand.Commands.Rotate90CW:
                    return "Rotate 90 CW";
                case TurretCommand.Commands.Rotate90CCW:
                    return "Rotate 90 CCW";
                case TurretCommand.Commands.Up:
                    return "Up";
                case TurretCommand.Commands.Down:
                    return "Down";
                case TurretCommand.Commands.Shoot:
                    return "Shoot";
                case TurretCommand.Commands.None:
                    return "None";
            }

            throw new Exception($"Строкового представления {value} в перечислении TurretCommand.Commands не существует");
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
