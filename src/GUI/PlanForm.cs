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
    public partial class PlanForm : Form
    {
        public PlanForm()
        {
            InitializeComponent();
        }

        private void dgvPlan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvPlan.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }
    }
}
