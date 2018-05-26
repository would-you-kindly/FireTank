using System.Windows.Forms;

namespace FireSafety
{
    public class DrawingSurface : Control
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            // Don't call base.OnPaint(e) to prevent forground painting
            base.OnPaint(e);
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            // Don't call base.OnPaintBackground(e) to prevent background painting
            base.OnPaintBackground(e);
        }
    }
}
