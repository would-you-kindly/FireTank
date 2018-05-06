using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class Rock : Entity
    {
        public Rock(Textures.ID idRock, ResourceHolder resources)
            : base(idRock, resources)
        {
            Utilities.CenterOrigin(sprite);
        }

        public override string ToString()
        {
            return "Скала";
        }
    }
}
