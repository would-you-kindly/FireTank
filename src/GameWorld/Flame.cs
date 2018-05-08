﻿using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class Flame : Entity
    {
        public Flame(Textures.ID id, ResourceHolder resources) :
            base(id, resources)
        {
            Utilities.CenterOrigin(sprite);
        }
    }
}