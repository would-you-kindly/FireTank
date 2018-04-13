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
        public int maxWaterPressure = 3;
        public int waterPressure;
        public bool up;

        public Turret(Textures.ID id, TextureHolder<Textures.ID> textures) :
            base(id, textures)
        {
            waterPressure = 0;
            up = false;

            // Выставляем Origin в центр картинки
            Utilities.CenterOrigin(sprite);
        }

        // Возвращает список координта, куда может попасть вода (или одну координату, если пушка поднята)
        public List<Vector2f> GetTargetPositions()
        {
            const int rotation = 45;
            List<Vector2f> targets = new List<Vector2f>();

            // Собираем все координаты, куда может попасть вода
            for (int i = 0; i < waterPressure; i++)
            {
                // Если пушка поднята, ищем дальнюю цель
                if (up && (i + 1 != waterPressure))
                {
                    continue;
                }

                // Вверх
                if (NormalizedRotation == rotation * 0)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2, sprite.Position.Y - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1)));
                // Вверх-вправо
                if (NormalizedRotation == rotation * 1)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1)));
                // Вправо
                if (NormalizedRotation == rotation * 2)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2));
                // Вправо-вниз
                if (NormalizedRotation == rotation * 3)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1)));
                // Вниз
                if (NormalizedRotation == rotation * 4)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2, sprite.Position.Y - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1)));
                // Вниз-влево
                if (NormalizedRotation == rotation * 5)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 + Utilities.TILE_SIZE * (i + 1)));
                // Влево
                if (NormalizedRotation == rotation * 6)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2));
                // Влево-вверх
                if (NormalizedRotation == rotation * 7)
                    targets.Add(new Vector2f(sprite.Position.X - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1), sprite.Position.Y - Utilities.TILE_SIZE / 2 - Utilities.TILE_SIZE * (i + 1)));
            }

            return targets;
        }
    }
}
