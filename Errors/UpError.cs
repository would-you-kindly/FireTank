using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class UpError : Error
    {
        public UpError()
            : base()
        {
            message += $"Нельзя поднимать пушку, если она уже поднята.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
