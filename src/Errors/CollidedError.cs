using System;

namespace FireSafety
{
    public class CollidedError : Error
    {
        private bool? frontalCollision;
        private Tank tank;
        private Entity entity;

        public CollidedError(Tank tank, Entity entity)
            : base()
        {
            this.frontalCollision = null;
            this.tank = tank;
            this.entity = entity;

            message += $"{tank.ToString()} столкнулся с объектом \"{entity.ToString()}\".";

            if (entity is Tank)
            {
                if (tank.sprite.Position == ((Tank)entity).sprite.Position &&
                    Math.Abs(tank.NormalizedRotation - ((Tank)entity).NormalizedRotation) == 180)
                {
                    frontalCollision = true;
                }
                else
                {
                    frontalCollision = false;
                }
            }
        }

        // Проверяем, должно ли произойти столкновение
        public bool? CheckTanksCollide()
        {
            if (entity is Tank)
            {
                // Танки оказались на одной и той же координате
                if (tank.sprite.Position == ((Tank)entity).sprite.Position)
                {
                    return true;
                }
                // Танки на разных координатах, но столкнулись бы лоб в лоб
                else if (frontalCollision == true)
                {
                    // TODO: Если танки стоят задними частями друг к другу и смотрят в противополжные стороны то это не столкновение
                    return frontalCollision;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return message;
        }
    }
}
