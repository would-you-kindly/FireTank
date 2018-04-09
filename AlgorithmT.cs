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
        ChildWindow window;
        ListBox lbMove;
        ListBox lbShoot;
        ListBox lbTurret;

        public AlgorithmT(TankColor color)
        {
            window = new ChildWindow("Algorithm");

            switch (color)
            {
                case TankColor.Red:
                    window.Renderer.TitleColor = Color.Red;
                    break;
                case TankColor.Blue:
                    window.Renderer.TitleColor = Color.Blue;
                    break;
                case TankColor.Yellow:
                    window.Renderer.TitleColor = Color.Yellow;
                    break;
                case TankColor.Green:
                    window.Renderer.TitleColor = Color.Green;
                    break;
            }
            window.Renderer.BackgroundColor = new Color(10, 10, 10, 50);
            window.Renderer.Borders = new Outline(1, 1, 1, 1);

            lbMove = new ListBox();
            //lbMove.Size = new Vector2f(100, 200);
            lbShoot = new ListBox();
            //lbShoot.Size = new Vector2f(100, 200);
            lbTurret = new ListBox();
            //lbTurret.Size = new Vector2f(100, 200);

            GuiT.getInstance().gui.Add(window);
        }


    }
}
