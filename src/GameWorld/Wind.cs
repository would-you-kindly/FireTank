using System;

namespace FireSafety
{
    public class Wind
    {
        // Направление ветра
        public enum Direction
        {
            Up,
            UpLeft,
            Left,
            LeftDown,
            Down,
            DownRight,
            Right,
            RightUp
        }

        public Direction direction;

        // Инициализирует объект Wind, устанавливает направление ветра в Direction.Up
        public Wind(Direction direction = Direction.Up)
        {
            this.direction = direction;
        }

        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }

        public override string ToString()
        {
            switch (direction)
            {
                case Direction.Up:
                    return "Вверх ↑";
                case Direction.UpLeft:
                    return "Вверх-влево ↖";
                case Direction.Left:
                    return "Влево ←";
                case Direction.LeftDown:
                    return "Влево-вниз ↙";
                case Direction.Down:
                    return "Вниз ↓";
                case Direction.DownRight:
                    return "Вниз-вправо ↘";
                case Direction.Right:
                    return "Вправо →";
                case Direction.RightUp:
                    return "Вправо-вверх ↗";
                default:
                    break;
            }

            throw new Exception("Неверно задано наравление ветра.");
        }
    }
}
