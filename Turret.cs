using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    public class Turret : Entity
    {
        public Turret(Textures.ID id, TextureHolder<Textures.ID> textures) :
            base(id, textures)
        {
            // Выставляем Origin в центр картинки
            Utilities.CenterOrigin(Sprite);
        }

        public Vector2f AgainstPosition
        {
            get
            {
                const int rotation = 45;
                //MessageBox.Show(sprite.Position.ToString());
                // TODO: Проконтролировать Rotation
                int degrees = (Math.Abs((int)Sprite.Rotation < 0 ? 360 + (int)Sprite.Rotation : (int)Sprite.Rotation)) % 360;
                switch (degrees)
                {
                    case rotation * 0:
                        return new Vector2f(Sprite.Position.X - 16, Sprite.Position.Y - 16 - 32);
                    case rotation * 1:
                        return new Vector2f(Sprite.Position.X - 16 + 32, Sprite.Position.Y - 16 - 32);
                    case rotation * 2:                        
                        return new Vector2f(Sprite.Position.X - 16 + 32, Sprite.Position.Y - 16);
                    case rotation * 3:                        
                        return new Vector2f(Sprite.Position.X - 16 + 32, Sprite.Position.Y - 16 + 32);
                    case rotation * 4:                        
                        return new Vector2f(Sprite.Position.X - 16, Sprite.Position.Y - 16 + 32);
                    case rotation * 5:                        
                        return new Vector2f(Sprite.Position.X - 16 - 32, Sprite.Position.Y - 16 + 32);
                    case rotation * 6:                        
                        return new Vector2f(Sprite.Position.X - 16 - 32, Sprite.Position.Y - 16);
                    case rotation * 7:                        
                        return new Vector2f(Sprite.Position.X - 16 - 32, Sprite.Position.Y - 16 - 32);
                    default:
                        throw new Exception("Невозможный угол поворота башни.");
                }
            }
        }
    }
}
