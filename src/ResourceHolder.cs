using SFML.Graphics;
using System.Collections.Generic;

namespace FireSafety
{
    public class ResourceHolder
    {
        private Dictionary<Textures.ID, Texture> textures;
        private Dictionary<Fonts.ID, Font> fonts;

        public ResourceHolder()
        {
            textures = new Dictionary<Textures.ID, Texture>();
            fonts = new Dictionary<Fonts.ID, Font>();
        }

        public void LoadTexture(Textures.ID id, string filename)
        {
            if (!textures.ContainsKey(id))
            {
                Texture texture = new Texture(filename);
                textures.Add(id, texture);
            }
        }

        public void LoadTexture(Textures.ID id, byte[] bytes)
        {
            if (!textures.ContainsKey(id))
            {
                Texture texture = new Texture(bytes);
                textures.Add(id, texture);
            }
        }

        public void LoadFont(Fonts.ID id, string filename)
        {
            if (!fonts.ContainsKey(id))
            {
                Font font = new Font(filename);
                fonts.Add(id, font);
            }
        }

        public void LoadFont(Fonts.ID id, byte[] bytes)
        {
            if (!fonts.ContainsKey(id))
            {
                Font font = new Font(bytes);
                fonts.Add(id, font);
            }
        }

        public Texture GetTexture(Textures.ID id)
        {
            return textures[id];
        }

        public Font GetFont(Fonts.ID id)
        {
            return fonts[id];
        }
    }
}
