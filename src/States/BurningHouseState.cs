using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class BurningHouseState : HouseState
    {
        public int needShootsToExtinguishCount = 3;
        public int currentShootsToExtinguishCount = 0;

        private static int algorithmActionNumber = -1;

        public BurningHouseState()
        {
            currentShootsToExtinguishCount = 0;
            algorithmActionNumber = -1;
        }

        public override void Extinguish(House house)
        {
            // Проверяем, был ли еще один выстрел на том же шаге алгоритма (эффект синергии)
            if (ParallelAlgorithm.GetInstance().currentAction == algorithmActionNumber)
            {
                currentShootsToExtinguishCount += 2;
            }

            algorithmActionNumber = ParallelAlgorithm.GetInstance().currentAction;

            if (++currentShootsToExtinguishCount >= needShootsToExtinguishCount)
            {
                house.state = new NormalHouseState();
            }
        }

        public override void Fire(House house, int power)
        {
            // Empty method
        }

        public override void Burn(House house)
        {
            house.state = new BurnedHouseState();
        }
    }
}
