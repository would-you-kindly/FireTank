using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class Turret : Entity
    {
        public Turret(Textures.ID id, TextureHolder<Textures.ID> textures) :
            base(id, textures)
        {
            // Выставляем Origin в центр картинки
            FloatRect rect = sprite.GetLocalBounds();
            sprite.Origin = new Vector2f(rect.Width / 2.0f, rect.Height / 2.0f);
        }

        public Vector2f AgainstPosition
        {
            get
            {
                // TODO: Проконтролировать Rotation
                int degrees = (Math.Abs((int)sprite.Rotation < 0 ? 360 + (int)sprite.Rotation : (int)sprite.Rotation)) % 360;
                switch (degrees)
                {
                    case 0:
                        return new Vector2f(192 + Sprite.Position.X, 224 + Sprite.Position.Y - 32);
                    case 90:
                        return new Vector2f(192 + Sprite.Position.X + 32, 224 + Sprite.Position.Y);
                    case 180:
                        return new Vector2f(192 + Sprite.Position.X, 224 + Sprite.Position.Y + 32);
                    case 270:
                        return new Vector2f(192 + Sprite.Position.X - 32, 224 + Sprite.Position.Y);
                    default:
                        throw new Exception("Невозможный угол поворота башни.");
                }
            }
        }
    }
}
