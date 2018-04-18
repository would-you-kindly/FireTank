﻿using SFML.Graphics;
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
        public static uint WIDTH_TILE_COUNT = 16;
        public static uint HEIGHT_TILE_COUNT = 16;
        public static uint WINDOW_WIDTH = (uint)TILE_SIZE * WIDTH_TILE_COUNT;
        public static uint WINDOW_HEIGHT = (uint)TILE_SIZE * HEIGHT_TILE_COUNT;
        public static int MAX_TANKS_COUNT = 4;
        public static int CURRENT_ACTION_NUMBER = 0;

        public static void CenterOrigin(Sprite sprite)
        {
            FloatRect rect = sprite.GetLocalBounds();
            sprite.Origin = new Vector2f(rect.Width / 2.0f, rect.Height / 2.0f);
        }

        public static void CenterOrigin(Text text)
        {
            FloatRect rect = text.GetLocalBounds();
            text.Origin = new Vector2f(rect.Width / 2.0f, rect.Height / 2.0f);
        }

        public static void CenterOrigin(Shape shape, float shiftX = 0.0f, float shiftY = 0.0f)
        {
            FloatRect rect = shape.GetLocalBounds();
            shape.Origin = new Vector2f(rect.Width / 2.0f + shiftX, rect.Height / 2.0f + shiftY);
        }
    }
}
