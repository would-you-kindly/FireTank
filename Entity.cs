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
        public Sprite sprite;

        public Entity()
        {
            sprite = new Sprite();
        }

        public Entity(Textures.ID id, TextureHolder<Textures.ID> textures)
        {
            Texture texture = textures.Get(id);
            sprite = new Sprite(texture);
        }

        public float NormalizedRotation
        {
            get
            {
                float rotation = sprite.Rotation;

                while (rotation < 0)
                {
                    rotation += 360;
                }
                while (rotation >= 360)
                {
                    rotation -= 360;
                }

                return rotation;
            }
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
    }
}
