using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class FontHolder<Identifier>
    {
        private Dictionary<Identifier, Font> fonts;

        public FontHolder()
        {
            fonts = new Dictionary<Identifier, Font>();
        }

        public void Load(Identifier id, string filename)
        {
            if (!fonts.ContainsKey(id))
            {
                Font texture = new Font(filename);
                fonts.Add(id, texture);
            }
        }

        public Font Get(Identifier id)
        {
            return fonts[id];
        }
    }
}
