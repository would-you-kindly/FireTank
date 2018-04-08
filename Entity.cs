using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;

namespace FireSafety
{
    public class Entity : Transformable, Drawable
    {
        protected Sprite sprite;

        public Entity()
        {
            sprite = new Sprite();
        }

        public Entity(Textures.ID id, TextureHolder<Textures.ID> textures)
        {
            Texture texture = textures.Get(id);
            sprite = new Sprite(texture);
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(sprite, states);
        }

        public virtual void Update(Time deltaTime)
        {
            // Empty method
        }

        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }
    }
}
