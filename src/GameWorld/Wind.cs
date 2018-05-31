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
        public int power;
        public int time;
        public int currentCycle;
        private int cycles;

        private string[] settings;

        // Инициализирует объект Wind, устанавливает направление ветра в Direction.Up
        public Wind(Direction direction = Direction.Up)
        {
            this.direction = direction;
        }

        public Wind(string parameters)
        {
            settings = parameters.Split();
            currentCycle = 0;
            cycles = settings.Length / 3;

            direction = ParseDirection(settings[currentCycle * 3 + 0]);
            power = int.Parse(settings[currentCycle * 3 + 1]);
            time = int.Parse(settings[currentCycle * 3 + 2]);
        }

        public void ChangeDirection(Direction direction)
        {
            this.direction = direction;
        }

        public void ChangeDirection()
        {
            time--;

            if (time == 0)
            {
                currentCycle = (currentCycle + 1) % cycles;

                direction = ParseDirection(settings[currentCycle * 3 + 0]);
                power = int.Parse(settings[currentCycle * 3 + 1]);
                time = int.Parse(settings[currentCycle * 3 + 2]);
            }
        }

        private Direction ParseDirection(string direction)
        {
            switch (direction)
            {
                case "up":
                    return Direction.Up;
                case "upleft":
                    return Direction.UpLeft;
                case "left":
                    return Direction.Left;
                case "leftdown":
                    return Direction.LeftDown;
                case "down":
                    return Direction.Down;
                case "downright":
                    return Direction.DownRight;
                case "right":
                    return Direction.Right;
                case "rightup":
                    return Direction.RightUp;
                default:
                    throw new Exception("Неверно указано направление ветра. Проверьте правильность значений переменных карты.");
            }
        }

        public override string ToString()
        {
            switch (direction)
            {
                case Direction.Up:
                    return Properties.Resources.WindUp;
                case Direction.UpLeft:
                    return Properties.Resources.WindUpLeft;
                case Direction.Left:
                    return Properties.Resources.WindLeft;
                case Direction.LeftDown:
                    return Properties.Resources.WindLeftDown;
                case Direction.Down:
                    return Properties.Resources.WindDown;
                case Direction.DownRight:
                    return Properties.Resources.WindDownRight;
                case Direction.Right:
                    return Properties.Resources.WindRight;
                case Direction.RightUp:
                    return Properties.Resources.WindRightUp;
                default:
                    break;
            }

            //return string.Join(" ", settings);

            throw new Exception("Неверно задано наравление ветра.");
        }
    }
}
