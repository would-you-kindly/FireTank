using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class InsufficientlyWaterError : Error
    {
        public InsufficientlyWaterError(Tank tank)
            : base()
        {
            message += $"Нельзя стрелять, если в запасе недостаточно воды ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
