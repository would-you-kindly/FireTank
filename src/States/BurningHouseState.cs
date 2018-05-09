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

        public BurningHouseState()
        {
            currentShootsToExtinguishCount = 0;
        }

        public override void Extinguish(House house)
        {
            if (currentShootsToExtinguishCount >= needShootsToExtinguishCount)
            {
                house.state = new NormalHouseState();
            }
            else
            {
                currentShootsToExtinguishCount++;
            }
        }

        public override void Fire(House house)
        {
            // Empty method
        }

        public override void Burn(House house)
        {
            house.state = new BurnedHouseState();
        }
    }
}
