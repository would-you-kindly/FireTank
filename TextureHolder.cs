using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class TextureHolder<Identifier>
    {
        private Dictionary<Identifier, Texture> textures;

        public TextureHolder()
        {
            textures = new Dictionary<Identifier, Texture>();
        }

        public void Load(Identifier id, string filename)
        {
            if (!textures.ContainsKey(id))
            {
                Texture texture = new Texture(filename);
                textures.Add(id, texture);
            }
        }

        public Texture Get(Identifier id)
        {
            return textures[id];
        }
    }
}
