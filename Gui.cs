using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    public class Gui
    {
        public FireSafetyForm form;

        public Gui(World world)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form = new FireSafetyForm(world);
            form.Show();
        }
    }
}
