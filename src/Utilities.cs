﻿using SFML.Graphics;
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
        public ModelContext context;

        private Utilities()
        {
            //TILE_SIZE = 32;
            //TANKS_COUNT = 2;
            //WIDTH_TILE_COUNT = 16;
            //HEIGHT_TILE_COUNT = 16;
            //WINDOW_WIDTH = (uint)TILE_SIZE * WIDTH_TILE_COUNT;
            //WINDOW_HEIGHT = (uint)TILE_SIZE * HEIGHT_TILE_COUNT;
            //INIT_BURNING_TREES = 0;
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

        public static MoveCommand.Commands ToMoveCommand(string value)
        {
            switch (value)
            {
                case "Forward":
                    return MoveCommand.Commands.Forward;
                case "Backward":
                    return MoveCommand.Commands.Backward;
                case "Rotate 45 CW":
                    return MoveCommand.Commands.Rotate45CW;
                case "Rotate 90 CW":
                    return MoveCommand.Commands.Rotate90CW;
                case "Rotate 45 CCW":
                    return MoveCommand.Commands.Rotate45CCW;
                case "Rotate 90 CCW":
                    return MoveCommand.Commands.Rotate90CCW;
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
                case "Refuel":
                    return ChargeCommand.Commands.Refuel;
                case "Pressure x1":
                    return ChargeCommand.Commands.PressureX1;
                case "Pressure x2":
                    return ChargeCommand.Commands.PressureX2;
                case "Charge":
                    return ChargeCommand.Commands.Charge;
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
                case ChargeCommand.Commands.PressureX1:
                    return "Pressure x1";
                case ChargeCommand.Commands.PressureX2:
                    return "Pressure x2";
                case ChargeCommand.Commands.Refuel:
                    return "Refuel";
                case ChargeCommand.Commands.Charge:
                    return "Charge";
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
