using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class ShootError : Error
    {
        public ShootError()
            : base()
        {
            message += $"Нельзя выполнять выстрел без давления.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
