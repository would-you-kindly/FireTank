using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public abstract class HouseState
    {
        public int hitPoints = 15;
        public readonly int timeToSpread = 7;
        public int currentTimeToSpread = 0;

        // Тушит дом
        public abstract void Extinguish(House house);

        // Поджигает дом
        public abstract void Fire(House house);

        // Сжигает дом
        public abstract void Burn(House house);

        // Проверяет, не горит ли дом
        public bool IsNormal()
        {
            return this is NormalHouseState;
        }

        // Проверяет, горит ли дом
        public bool IsBurning()
        {
            return this is BurningHouseState;
        }

        // Проверяет, сгорел ли дом
        public bool IsBurned()
        {
            return this is BurnedHouseState;
        }
    }
}
