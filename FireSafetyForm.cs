using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    partial class FireSafetyForm : Form
    {
        public FireSafetyForm(Algorithm algorithm)
        {
            InitializeComponent();

            AlgorithmForm algorithmForm = new AlgorithmForm(algorithm);
            algorithmForm.MdiParent = this;
            algorithmForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void algorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
