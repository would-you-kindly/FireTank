using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class NormalHouseState : HouseState
    {
        public NormalHouseState()
        {
            currentTimeToSpread = 0;
        }

        public override void Extinguish(House house)
        {
            // Empty method
        }

        public override void Fire(House house)
        {
            if (currentTimeToSpread == timeToSpread)
            {
                house.state = new BurningHouseState();
            }
            else
            {
                currentTimeToSpread++;
            }
        }

        public override void Burn(House house)
        {
            // Empty method
        }
    }
}
