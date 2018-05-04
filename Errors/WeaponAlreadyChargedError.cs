using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class WeaponAlreadyChargedError : Error
    {
        public WeaponAlreadyChargedError()
            : base()
        {
            message += $"Нельзя заряжать пушку, если она уже заряжена.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
