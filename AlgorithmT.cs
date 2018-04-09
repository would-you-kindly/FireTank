using FireSafety;
using System;
using System.Windows.Input;
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
        private Theme theme;
        private Label lblMove;
        private Label lblShoot;
        private Label lblTurret;
        private ListBox lbMove;
        private ListBox lbShoot;
        private ListBox lbTurret;
        private ComboBox cbMove;
        private ComboBox cbShoot;
        private ComboBox cbTurret;
        private Grid grid;

        public AlgorithmT()
        {
            theme = new Theme("themes/Black.txt");

            InitWindow();
            InitLabel();
            InitListBox();
            InitComboBox();
            InitGrid();

            window.Add(grid);
        }

        private void InitWindow()
        {
            window = new ChildWindow("Algorithm");
            window.Size = new Vector2f(300, 240);
            window.SetRenderer(theme.getRenderer("ChildWindow"));
            window.Closed += Window_Closed;

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

            window.Renderer.BackgroundColor = new Color(10, 10, 10, 30);
            window.Renderer.TitleBarColor = new Color(10, 10, 10, 30);
            window.Renderer.Borders = new Outline(1, 1, 1, 1);
        }

        private void InitGrid()
        {
            grid = new Grid();
            grid.AddWidget(lblMove, 0, 0);
            grid.AddWidget(lblShoot, 0, 1);
            grid.AddWidget(lblTurret, 0, 2);
            grid.AddWidget(lbMove, 1, 0);
            grid.AddWidget(lbShoot, 1, 1);
            grid.AddWidget(lbTurret, 1, 2);
            grid.AddWidget(cbMove, 2, 0);
            grid.AddWidget(cbShoot, 2, 1);
            grid.AddWidget(cbTurret, 2, 2);
        }

        private void InitComboBox()
        {
            cbMove = new ComboBox();
            cbMove.Size = new Vector2f(100, 20);
            cbMove.SetRenderer(theme.getRenderer("ComboBox"));
            cbMove.ItemSelected += CbMove_ItemSelected;
            cbMove.AddItem("Forfard");
            cbMove.AddItem("Backward");
            cbMove.AddItem("45 CW");
            cbMove.AddItem("45 CCW");
            cbMove.AddItem("90 CW");
            cbMove.AddItem("90 CCW");
            cbMove.AddItem("None");
            cbShoot = new ComboBox();
            cbShoot.Size = new Vector2f(100, 20);
            cbShoot.SetRenderer(theme.getRenderer("ComboBox"));
            cbShoot.ItemSelected += CbShoot_ItemSelected;
            cbShoot.AddItem("Preasure");
            cbShoot.AddItem("Shoot");
            cbShoot.AddItem("None");
            cbTurret = new ComboBox();
            cbTurret.Size = new Vector2f(100, 20);
            cbTurret.SetRenderer(theme.getRenderer("ComboBox"));
            cbTurret.ItemSelected += CbTurret_ItemSelected;
            cbTurret.AddItem("45 CW");
            cbTurret.AddItem("45 CCW");
            cbTurret.AddItem("90 CW");
            cbTurret.AddItem("90 CCW");
            cbTurret.AddItem("Up");
            cbTurret.AddItem("Down");
            cbTurret.AddItem("None");
        }

        private void InitListBox()
        {
            lbMove = new ListBox();
            lbMove.Size = new Vector2f(100, 200);
            lbMove.SetRenderer(theme.getRenderer("ListBox"));
            lbShoot = new ListBox();
            lbShoot.Size = new Vector2f(100, 200);
            lbShoot.SetRenderer(theme.getRenderer("ListBox"));
            lbTurret = new ListBox();
            lbTurret.Size = new Vector2f(100, 200);
            lbTurret.SetRenderer(theme.getRenderer("ListBox"));
        }

        private void InitLabel()
        {
            lblMove = new Label("Move");
            lblMove.SetRenderer(theme.getRenderer("Label"));
            lblShoot = new Label("Shoot");
            lblShoot.SetRenderer(theme.getRenderer("Label"));
            lblTurret = new Label("Turret");
            lblTurret.SetRenderer(theme.getRenderer("Label"));
        }

        private void CbTurret_ItemSelected(object sender, SignalArgsItem e)
        {
            if (e.Item != string.Empty)
            {
                lbTurret.AddItem(e.Item);
                ((ComboBox)sender).DeselectItem();
            }
        }

        private void CbShoot_ItemSelected(object sender, SignalArgsItem e)
        {
            if (e.Item != string.Empty)
            {
                lbShoot.AddItem(e.Item);
                ((ComboBox)sender).DeselectItem();
            }
        }

        private void CbMove_ItemSelected(object sender, SignalArgsItem e)
        {
            if (e.Item != string.Empty)
            {
                lbMove.AddItem(e.Item);
                ((ComboBox)sender).DeselectItem();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ((ChildWindow)sender).Visible = false;
        }
    }
}
