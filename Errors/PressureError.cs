using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class PressureError : Error
    {
        public PressureError(Tank tank)
            : base()
        {
            message += $"Нельзя переполнять давление воды ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
