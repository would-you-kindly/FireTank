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
