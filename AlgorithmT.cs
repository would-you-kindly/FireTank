using FireSafety;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGUI;
using SFML.Graphics;
using SFML.System;

namespace Interface
{
    public class AlgorithmT
    {
        public ChildWindow window;

        public AlgorithmT()
        {
            window = new ChildWindow("Algorithm");
            Theme theme = new Theme("themes/Black.txt");
            window.SetRenderer(theme.getRenderer("ChildWindow"));

            //switch (color)
            //{
            //    case TankColor.Red:
            //        window.Renderer.TitleColor = Color.Red;
            //        break;
            //    case TankColor.Blue:
            //        window.Renderer.TitleColor = Color.Blue;
            //        break;
            //    case TankColor.Yellow:
            //        window.Renderer.TitleColor = Color.Yellow;
            //        break;
            //    case TankColor.Green:
            //        window.Renderer.TitleColor = Color.Green;
            //        break;
            //}

            window.Renderer.BackgroundColor = new Color(10, 10, 10, 50);
            window.Renderer.Borders = new Outline(1, 1, 1, 1);

            ListBox lbMove = new ListBox();
            lbMove.Size = new Vector2f(100, 200);
            lbMove.AddItem("Forward");
            lbMove.AddItem("Forward");
            ListBox lbShoot = new ListBox();
            lbShoot.Size = new Vector2f(100, 200);
            lbShoot.AddItem("Forward");
            ListBox lbTurret = new ListBox();
            lbTurret.Size = new Vector2f(100, 200);
            lbTurret.AddItem("Forward");
            lbTurret.AddItem("Forward");
            lbTurret.AddItem("Forward");
            lbTurret.Enabled = true;

            ComboBox cbMove = new ComboBox();
            cbMove.Size = new Vector2f(100, 20);
            cbMove.AddItem("Forfard");
            cbMove.AddItem("Backward");
            ComboBox cbShoot = new ComboBox();
            cbShoot.AddItem("Increase");
            cbShoot.AddItem("Shopt");
            cbShoot.Size = new Vector2f(100, 20);
            ComboBox cbTurret = new ComboBox();
            cbTurret.AddItem("90 CW");
            cbTurret.AddItem("90 CCW");
            cbTurret.Size = new Vector2f(100, 20);

            Grid grid = new Grid();
            grid.AddWidget(new Label("Move"), 0, 0);
            grid.AddWidget(new Label("Shoot"), 0, 1);
            grid.AddWidget(new Label("Turret"), 0, 2);
            grid.AddWidget(lbMove, 1, 0);
            grid.AddWidget(lbShoot, 1, 1);
            grid.AddWidget(lbTurret, 1, 2);
            grid.AddWidget(cbMove, 2, 0);
            grid.AddWidget(cbShoot, 2, 1);
            grid.AddWidget(cbTurret, 2, 2);

            window.Add(grid);

        }

        private void LbShoot_ItemSelected(object sender, SignalArgsItem e)
        {
            Console.Write("accept");
        }
    }
}
