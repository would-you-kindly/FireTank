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
    public partial class InsertActionForm : Form
    {
        int number;
        Action action;

        public int Number
        {
            get
            {
                return number;
            }
        }

        public Action Action
        {
            get
            {
                return action;
            }
        }

        public InsertActionForm(int count)
        {
            InitializeComponent();

            number = 0;
            action = new Action(MoveCommand.Commands.None, 
                ChargeCommand.Commands.None, TurretCommand.Commands.None);

            for (int i = 0; i <= count; i++)
            {
                cbNumber.Items.Add(i + 1);
            }

            cbNumber.SelectedIndex = 0;
            cbMove.SelectedIndex = cbMove.Items.Count - 1;
            cbCharge.SelectedIndex = cbCharge.Items.Count - 1;
            cbTurret.SelectedIndex = cbTurret.Items.Count - 1;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            number = cbNumber.SelectedIndex;

            action = new Action(Utilities.ToMoveCommand((string)cbMove.Items[cbMove.SelectedIndex]),
                Utilities.ToChargeCommand((string)cbCharge.Items[cbCharge.SelectedIndex]),
                Utilities.ToTurretCommand((string)cbTurret.Items[cbTurret.SelectedIndex]));

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
