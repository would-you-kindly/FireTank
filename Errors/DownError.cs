using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class DownError : Error
    {
        public DownError()
            : base()
        {
            message += $"Нельзя опускать пушку, если она уже опущена.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
