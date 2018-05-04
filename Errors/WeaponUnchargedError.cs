using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class WeaponUnchargedError : Error
    {
        public WeaponUnchargedError(Tank tank)
            : base()
        {
            message += $"Нельзя стрелять из пушки, если она еще не заряжена ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
