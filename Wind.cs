using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class Wind
    {
        // Направление ветра
        public enum Direction
        {
            Up,
            Left,
            Down,
            Rigth
        }

        public Direction direction;

        // Инициализирует объект Wind, устанавливает направление ветра в Direction.Up
        public Wind(Direction direction = Direction.Up)
        {
            this.direction = direction;
        }

        // Устанавливает новое направление ветра и возвращает предыдущее
        public Direction ChangeDirection(Direction newDirection)
        {
            Direction prevDirection = direction;
            direction = newDirection;

            return prevDirection;
        }
    }
}
