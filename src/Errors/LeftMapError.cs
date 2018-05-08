using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class LeftMapError : Error
    {
        public LeftMapError(Tank tank)
            : base()
        {
            message += $"{tank.ToString()} покинул пределы карты.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
