using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGUI;

namespace Interface
{
    public class MenuT
    {
        public MenuBar menuBar;

        public MenuT()
        {
            Theme theme = new Theme("themes/Black.txt");
            menuBar = new MenuBar();
            menuBar.SetRenderer(theme.getRenderer("MenuBar"));

            menuBar.AddMenu("File");
            menuBar.AddMenuItem("File", "Save algorithm");
            menuBar.AddMenuItem("File", "Save algorithm as...");
            menuBar.AddMenuItem("File", "Load algorithm");
            menuBar.AddMenuItem("File", "Load level");
            menuBar.AddMenuItem("File", "Load level");
            menuBar.AddMenu("Window");
            menuBar.AddMenuItem("Window", "Tank algorithm");
            menuBar.AddMenuItem("Tank algorithm", "Red");
            menuBar.AddMenuItem("Tank algorithm", "Blue");
            menuBar.AddMenuItem("Tank algorithm", "Yellow");
            menuBar.AddMenuItem("Tank algorithm", "Green");
        }
    }
}
