using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class WeaponUpChargeError : Error
    {
        public WeaponUpChargeError()
            : base()
        {
            message += $"Нельзя заряжать пушку, если она поднята.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
