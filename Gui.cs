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
        private ParallelAlgorithm _parallelAlgorithm;

        public FireSafetyForm form;

        public Gui(List<Tank> tanks, ParallelAlgorithm parallelAlgorithm)
        {
            _parallelAlgorithm = parallelAlgorithm;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new FireSafetyForm(tanks, parallelAlgorithm);
            form.Show();
        }
    }
}
