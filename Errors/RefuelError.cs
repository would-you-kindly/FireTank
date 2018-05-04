using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class RefuelError : Error
    {
        public RefuelError()
        : base()
        {
            message += $"Нельзя переполнять запасы воды.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
