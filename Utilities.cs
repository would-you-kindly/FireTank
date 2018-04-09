using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public static class Utilities
    {
        // TODO: Грузить эти значения из xml
        public static int TILE_SIZE = 32;
        public static int TANKS_COUNT = 2;
        public static uint WINDOW_WIDTH = 640;
        public static uint WINDOW_HEIGHT = 480;

        public static void CenterOrigin(Sprite sprite)
        {
            FloatRect rect = sprite.GetLocalBounds();
            sprite.Origin = new Vector2f(rect.Width / 2.0f, rect.Height / 2.0f);
        }
    }
}
