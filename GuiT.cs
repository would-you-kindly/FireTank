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
        private static GuiT instance;
        public RenderWindow renderWindow;
        public Gui gui;

        private GuiT()
        {
            renderWindow = new RenderWindow(new VideoMode(Utilities.WINDOW_WIDTH, Utilities.WINDOW_HEIGHT), "FireSafety");
            gui = new Gui(renderWindow);
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
