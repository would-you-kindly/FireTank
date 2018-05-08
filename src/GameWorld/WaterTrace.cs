using SFML.Graphics;
using SFML.System;
using System;

namespace FireSafety
{
    public class WaterTrace
    {
        RectangleShape trace = new RectangleShape();
        CircleShape centre = new CircleShape();

        public WaterTrace(bool up, Vector2f position, int pressure, float degrees)
        {
            // Траектория, по которой летит вода
            if (up)
            {
                trace.FillColor = Color.Cyan;
                centre.FillColor = Color.Cyan;
            }
            else
            {
                trace.FillColor = Color.Magenta;
                centre.FillColor = Color.Magenta;
            }
            trace.Position = position;
            trace.Rotation = degrees - 90;
            if ((Utilities.NormalizedRotation(trace.Rotation) / 45) % 2 == 1)
            {
                trace.Size = new Vector2f(pressure * (float)Math.Sqrt(Math.Pow(Utilities.TILE_SIZE, 2.0) + Math.Pow(Utilities.TILE_SIZE, 2.0)), 1);
            }
            else
            {
                trace.Size = new Vector2f(pressure * Utilities.TILE_SIZE, 1);
            }

            // Точка, из которой стреляли
            centre.Position = position;
            centre.Radius = 3;
            Utilities.CenterOrigin(centre);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(trace, states);
            target.Draw(centre, states);
        }
    }
}
