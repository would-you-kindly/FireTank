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
    public partial class InfoForm : Form
    {
        public TankController tankController;

        public InfoForm()
        {
            InitializeComponent();

            //tankController = new TankController(label3);
        }
    }
}
