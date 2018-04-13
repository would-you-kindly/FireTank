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
    partial class AlgorithmForm : Form
    {
        Algorithm _algorithm;

        public AlgorithmForm(Algorithm algorithm)
        {
            InitializeComponent();

            _algorithm = algorithm;

            dgvAlgorithm.Focus();
            dgvAlgorithm.ClearSelection();
        }

        private void cbShootCommandsCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommand((ComboBox)sender);
        }

        private void cbShoot_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommand((ComboBox)sender);
        }

        private void cbTurret_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommand((ComboBox)sender);
        }

        private void SetCommand(ComboBox cb)
        {
            int index = 0;
            switch (cb.Name)
            {
                case "cbMove":
                    index = 0;
                    break;
                case "cbShoot":
                    index = 1;
                    break;
                case "cbTurret":
                    index = 2;
                    break;
            }

            if (dgvAlgorithm.SelectedCells.Count != 0 &&
                dgvAlgorithm.SelectedCells[0].ColumnIndex == index)
            {
                dgvAlgorithm.Rows[dgvAlgorithm.SelectedCells[0].RowIndex].Cells[index].Value = cb.SelectedItem.ToString();
            }
            else
            {
                dgvAlgorithm.Rows.Add("None", "None", "None");
                dgvAlgorithm.Rows[dgvAlgorithm.RowCount - 1].Cells[index].Value = cb.SelectedItem.ToString();
            }

            dgvAlgorithm.Focus();
            dgvAlgorithm.ClearSelection();
        }

        // Составляет алгоритм на основе данных в элементах управления
        public void BuildAlgorithm()
        {
            List<Action> listActions = new List<Action>();
            for (int i = 0; i < dgvAlgorithm.Rows.Count; i++)
            {
                listActions.Add(new Action());
                SetMoveCommands(listActions, i);
                SetShootCommands(listActions, i);
                SetTurretCommands(listActions, i);
            }

            _algorithm.Actions = new Queue<Action>(listActions);
        }

        private void SetTurretCommands(List<Action> listActions, int i)
        {
            switch (dgvAlgorithm.Rows[i].Cells[2].Value.ToString())
            {
                case "Rotate 45 CW":
                    listActions[i].commands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate45CW);
                    break;
                case "Rotate 45 CCW":
                    listActions[i].commands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate45CCW);
                    break;
                case "Rotate 90 CW":
                    listActions[i].commands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate90CW);
                    break;
                case "Rotate 90 CCW":
                    listActions[i].commands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate90CCW);
                    break;
                case "Up":
                    listActions[i].commands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Up);
                    break;
                case "Down":
                    listActions[i].commands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Down);
                    break;
                default:
                    break;
            }
        }

        private void SetShootCommands(List<Action> listActions, int i)
        {
            switch (dgvAlgorithm.Rows[i].Cells[1].Value.ToString())
            {
                case "Increase water pressure":
                    listActions[i].commands[(int)Action.Types.Shoot] = new ShootCommand(ShootCommand.Commands.IncreaseWaterPressure);
                    break;
                case "Shoot":
                    listActions[i].commands[(int)Action.Types.Shoot] = new ShootCommand(ShootCommand.Commands.Shoot);
                    break;
                default:
                    break;
            }
        }

        private void SetMoveCommands(List<Action> listActions, int i)
        {
            switch (dgvAlgorithm.Rows[i].Cells[0].Value.ToString())
            {
                case "Forward":
                    listActions[i].commands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Forward);
                    break;
                case "Backward":
                    listActions[i].commands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Backward);
                    break;
                case "Rotate 90 CW":
                    listActions[i].commands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate90CW);
                    break;
                case "Rotate 90 CCW":
                    listActions[i].commands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate90CCW);
                    break;
                case "Rotate 45 CW":
                    listActions[i].commands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate45CW);
                    break;
                case "Rotate 45 CCW":
                    listActions[i].commands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate45CCW);
                    break;
                default:
                    break;
            }
        }

        private void dgvAlgorithm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Отменяем выделение при нажатии "Escape"
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvAlgorithm.ClearSelection();
            }
        }
    }
}
