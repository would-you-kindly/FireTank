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
        private Theme theme;

        public MenuT()
        {
            theme = new Theme("themes/Black.txt");
            menuBar = new MenuBar();
            menuBar.SetRenderer(theme.getRenderer("MenuBar"));

            menuBar.AddMenu("File");
            menuBar.AddMenuItem("File", "Save algorithm");
            menuBar.AddMenuItem("File", "Save algorithm as...");
            menuBar.AddMenuItem("File", "Load algorithm");
            menuBar.AddMenuItem("File", "Load level");
            menuBar.AddMenuItem("File", "Load level");
            menuBar.AddMenu("Window");

            menuBar.MenuItemClicked += MenuBar_MenuItemClicked;
        }

        private void MenuBar_MenuItemClicked(object sender, SignalArgsString e)
        {
            switch (e.Value)
            {
                case "Save algorithm":
                    GuiT.getInstance().SaveParallelAlgorithm();
                    break;
                case "Load algorithm":
                    GuiT.getInstance().LoadParallelAlgorithm();
                    break;
                default:
                    break;
            }
        }
    }
}
