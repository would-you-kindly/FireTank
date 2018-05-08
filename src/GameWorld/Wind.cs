using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
