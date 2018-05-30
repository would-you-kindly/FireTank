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

        public ModelContext context;

        private Utilities()
        {
            TILE_SIZE = 32;
            TANKS_COUNT = 2;
            WIDTH_TILE_COUNT = 16;
            HEIGHT_TILE_COUNT = 16;
            INIT_BURNING_TREES = 0;
            MAX_TANKS_COUNT = 6;

            context = new ModelContext(Settings.GetInstance().connectionString);
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

        public static MoveCommand.Commands ToMoveCommandRus(string value)
        {
            switch (value)
            {
                case "Вперед":
                    return MoveCommand.Commands.Forward;
                case "Назад":
                    return MoveCommand.Commands.Backward;
                case "45° по ч.с.":
                    return MoveCommand.Commands.Rotate45CW;
                case "90° по ч.с.":
                    return MoveCommand.Commands.Rotate90CW;
                case "45° пр. ч.с.":
                    return MoveCommand.Commands.Rotate45CCW;
                case "90° пр. ч.с.":
                    return MoveCommand.Commands.Rotate90CCW;
                case "Вперед 45° по ч.с.":
                    return MoveCommand.Commands.Forward45CW;
                case "Вперед 45° пр. ч.с.":
                    return MoveCommand.Commands.Forward45CCW;
                case "Назад 45° по ч.с.":
                    return MoveCommand.Commands.Backward45CW;
                case "Назад 45° пр. ч.с.":
                    return MoveCommand.Commands.Backward45CCW;
                case "Бездействие":
                    return MoveCommand.Commands.None;
            }

            throw new Exception($"Строкового представления {value} в перечислении MoveCommand.Commands не существует.");
        }

        public static ChargeCommand.Commands ToChargeCommandRus(string value)
        {
            switch (value)
            {
                case "Давление +1":
                    return ChargeCommand.Commands.PressureX1;
                case "Давление +2":
                    return ChargeCommand.Commands.PressureX2;
                case "Зарядить":
                    return ChargeCommand.Commands.Charge;
                case "Пополнить запас":
                    return ChargeCommand.Commands.Refuel;
                case "Бездействие":
                    return ChargeCommand.Commands.None;
            }

            throw new Exception($"Строкового представления {value} в перечислении ChargeCommand.Commands не существует.");
        }

        public static TurretCommand.Commands ToTurretCommandRus(string value)
        {
            switch (value)
            {
                case "45° по ч.с.":
                    return TurretCommand.Commands.Rotate45CW;
                case "45° пр. ч.с.":
                    return TurretCommand.Commands.Rotate45CCW;
                case "90° по ч.с.":
                    return TurretCommand.Commands.Rotate90CW;
                case "90° пр. ч.с.":
                    return TurretCommand.Commands.Rotate90CCW;
                case "Поднять":
                    return TurretCommand.Commands.Up;
                case "Опустить":
                    return TurretCommand.Commands.Down;
                case "Выстрелить":
                    return TurretCommand.Commands.Shoot;
                case "Бездействие":
                    return TurretCommand.Commands.None;
            }

            throw new Exception($"Строкового представления {value} в перечислении TurretCommand.Commands не существует.");
        }

        public static string ToMoveStringRus(MoveCommand.Commands value)
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

        public static string ToChargeStringRus(ChargeCommand.Commands value)
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

        public static string ToTurretStringRus(TurretCommand.Commands value)
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
