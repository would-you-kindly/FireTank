using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class PressureError : Error
    {
        public PressureError()
            : base()
        {
            message += $"Нельзя переполнять давление воды.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
