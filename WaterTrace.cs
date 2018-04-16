using OpenTK.Graphics;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class WaterTrace
    {
        Vector2f from;
        Vector2f to;

        public WaterTrace(Vector2f from, Vector2f to)
        {
            this.from = from;
            this.to = to;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            GL.LineWidth(3);
            GL.Color3(System.Drawing.Color.Azure);
            GL.Begin(BeginMode.Lines);
            GL.Vertex2(from.X, from.Y);
            GL.Vertex2(to.X, to.Y);
            GL.End();
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
