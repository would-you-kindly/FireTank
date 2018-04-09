using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGUI;
using FireSafety;

namespace Interface
{
    public class GuiT
    {
        public RenderWindow renderWindow;
        public Gui gui;

        private static GuiT instance;
        public AlgorithmT algorithmT;

        private GuiT()
        {
            renderWindow = new RenderWindow(new VideoMode(Utilities.WINDOW_WIDTH, Utilities.WINDOW_HEIGHT), "FireSafety");
            gui = new Gui(renderWindow);
            algorithmT = new AlgorithmT(TankColor.Blue);

            gui.Add(algorithmT.window);
        }

        public static GuiT getInstance()
        {
            if (instance == null)
                instance = new GuiT();
            return instance;
        }

        public void Draw()
        {
            gui.Draw();
        }
    }
}
