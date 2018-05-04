using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class DownError : Error
    {
        public DownError(Tank tank)
            : base()
        {
            message += $"Нельзя опускать пушку, если она уже опущена ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
