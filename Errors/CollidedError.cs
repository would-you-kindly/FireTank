using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class CollidedError : Error
    {
        public CollidedError(Tank tank, Entity entity)
            : base()
        {
            message += $"{tank.ToString()} столкнулся с объектом \"{entity.ToString()}\".";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
