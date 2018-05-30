using System;
using SFML.Graphics;
using SFML.System;

namespace FireSafety
{
    public class CoordinateSystem
    {
        private uint width;
        private uint height;
        private Text text;

        public CoordinateSystem(uint width, uint height, ResourceHolder resources)
        {
            this.width = width;
            this.height = height;

            text = new Text(string.Empty, resources.GetFont(Fonts.ID.Sansation), 12);
            text.FillColor = Color.Black;
            text.OutlineThickness = 0.2f;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            // Пишем буквы (по горизонтали)
            for (int i = 0; i < width; i++)
            {
                char symbol = (char)(65 + i);
                text.DisplayedString = symbol.ToString();
                text.Position = new Vector2f((float)(i * Utilities.GetInstance().TILE_SIZE +
                    Utilities.GetInstance().TILE_SIZE / 2.0), (float)(Utilities.GetInstance().TILE_SIZE / 6.0));
                Utilities.CenterOrigin(text);
                text.Draw(target, states);
            }

            // Пишем цифры (по вертикали)
            for (int i = 0; i < height; i++)
            {
                int symbol = i + 1;
                text.DisplayedString = symbol.ToString();
                text.Position = new Vector2f((float)(Utilities.GetInstance().TILE_SIZE / 6.0), 
                    (float)(i * Utilities.GetInstance().TILE_SIZE + Utilities.GetInstance().TILE_SIZE / 2.0));
                Utilities.CenterOrigin(text);
                text.Draw(target, states);
            }
        }
    }
}