using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    partial class AlgorithmForm : Form
    {
        Algorithm _algorithm;

        Stopwatch clock = new Stopwatch();
        bool keyPressed = false;
        private const int timeToHold = 200;

        public AlgorithmForm(Algorithm algorithm)
        {
            InitializeComponent();

            _algorithm = algorithm;

            dgvAlgorithm.Focus();
            dgvAlgorithm.ClearSelection();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle = 0x200;
                return createParams;
            }
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

        public void SetCommand(ComboBox cb)
        {
            if (cb.SelectedIndex == -1)
            {
                return;
            }

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

            // Изменяем команды действия алгоритма
            if (dgvAlgorithm.SelectedCells.Count != 0 && rbtnChange.Checked)
            {
                dgvAlgorithm.Rows[dgvAlgorithm.SelectedCells[0].RowIndex].Cells[index].Value = cb.SelectedItem.ToString();
            }
            // Вставляем новое действие выше выделенного
            else if (dgvAlgorithm.SelectedCells.Count != 0 && rbtnInsertBefore.Checked)
            {
                int beforeIndex = dgvAlgorithm.SelectedRows[0].Index;
                dgvAlgorithm.Rows.Insert(beforeIndex, "None", "None", "None");
                dgvAlgorithm.Rows[beforeIndex].Cells[index].Value = cb.SelectedItem.ToString();
            }
            // Вставляем новое действие ниже выделенного
            else if (dgvAlgorithm.SelectedCells.Count != 0 && rbtnInsertAfter.Checked)
            {
                int afterIndex = dgvAlgorithm.SelectedRows[0].Index + 1;
                dgvAlgorithm.Rows.Insert(afterIndex, "None", "None", "None");
                dgvAlgorithm.Rows[afterIndex].Cells[index].Value = cb.SelectedItem.ToString();
            }
            // Вставляем новое действие в конец алгоритма
            else
            {
                dgvAlgorithm.Rows.Add("None", "None", "None");
                dgvAlgorithm.Rows[dgvAlgorithm.RowCount - 1].Cells[index].Value = cb.SelectedItem.ToString();
            }

            // Перемещаем таблицу вниз, чтобы были видны новые добавленные дейтсвия
            try
            {
                dgvAlgorithm.FirstDisplayedScrollingRowIndex = dgvAlgorithm.Rows.Count - 1;
            }
            catch (Exception)
            {
                // Ignore exception
            }
            dgvAlgorithm.ClearSelection();
            dgvAlgorithm.Focus();
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
                case "Pressure":
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

        }

        private void DeleteAction()
        {
            if (dgvAlgorithm.SelectedRows.Count != 0)
            {
                dgvAlgorithm.Rows.RemoveAt(dgvAlgorithm.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Выберите строку алгоритма, чтобы удалить ее.",
                    "Удаление строки алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        private void dgvAlgorithm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyPressed)
            {
                return;
            }
            keyPressed = true;

            clock.Restart();

            // Отменяем выделение
            if (e.KeyCode == Keys.Escape)
            {
                dgvAlgorithm.ClearSelection();
            }

            // Удаляем выделенное действие
            if (e.KeyCode == Keys.Delete)
            {
                DeleteAction();
            }

            // Обрабатываем горячие клавиши добавления команд движения
            if (e.KeyCode == Keys.F)
            {
                cbMove.SelectedIndex = -1;
                cbMove.SelectedItem = "Forward";
            }

            if (e.KeyCode == Keys.B)
            {
                cbMove.SelectedIndex = -1;
                cbMove.SelectedItem = "Backward";
            }

            if (e.KeyCode == Keys.N)
            {
                cbMove.SelectedIndex = -1;
                cbMove.SelectedItem = "None";
            }

            // Обрабатываем горячие клавиши добавления команд выстрела
            if (e.KeyCode == Keys.P)
            {
                cbShoot.SelectedIndex = -1;
                cbShoot.SelectedItem = "Pressure";
            }

            if (e.KeyCode == Keys.S)
            {
                cbShoot.SelectedIndex = -1;
                cbShoot.SelectedItem = "Shoot";
            }

            // Обрабатываем горячие клавиши добавления команд турели
            if (e.KeyCode == Keys.U)
            {
                cbTurret.SelectedIndex = -1;
                cbTurret.SelectedItem = "Up";
            }

            if (e.KeyCode == Keys.D)
            {
                cbTurret.SelectedIndex = -1;
                cbTurret.SelectedItem = "Down";
            }
        }

        private void dgvAlgorithm_KeyUp(object sender, KeyEventArgs e)
        {
            keyPressed = false;
            clock.Stop();

            // Обрабатываем короткое/долгое нажатие горячей клавиши для добавления разных команд движения
            if (e.KeyCode == Keys.NumPad8)
            {
                if (clock.ElapsedMilliseconds < timeToHold)
                {
                    cbMove.SelectedIndex = -1;
                    cbMove.SelectedItem = "Rotate 45 CW";
                }
                else
                {
                    cbMove.SelectedIndex = -1;
                    cbMove.SelectedItem = "Rotate 90 CW";
                }
            }

            if (e.KeyCode == Keys.NumPad2)
            {
                if (clock.ElapsedMilliseconds < timeToHold)
                {
                    cbMove.SelectedIndex = -1;
                    cbMove.SelectedItem = "Rotate 45 CCW";
                }
                else
                {
                    cbMove.SelectedIndex = -1;
                    cbMove.SelectedItem = "Rotate 90 CCW";
                }
            }

            // Обрабатываем короткое/долгое нажатие горячей клавиши для добавления разных команд турели
            if (e.KeyCode == Keys.NumPad6)
            {
                if (clock.ElapsedMilliseconds < timeToHold)
                {
                    cbTurret.SelectedIndex = -1;
                    cbTurret.SelectedItem = "Rotate 45 CW";
                }
                else
                {
                    cbTurret.SelectedIndex = -1;
                    cbTurret.SelectedItem = "Rotate 90 CW";
                }
            }

            if (e.KeyCode == Keys.NumPad4)
            {
                if (clock.ElapsedMilliseconds < timeToHold)
                {
                    cbTurret.SelectedIndex = -1;
                    cbTurret.SelectedItem = "Rotate 45 CCW";
                }
                else
                {
                    cbTurret.SelectedIndex = -1;
                    cbTurret.SelectedItem = "Rotate 90 CCW";
                }
            }
        }

        //private const int GWL_STYLE = -16;
        //private const int WS_CLIPSIBLINGS = 1 << 26;

        //[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        //public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
        //[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
        //public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);

        //protected override void OnLoad(EventArgs e)
        //{
        //    int style = (int)((long)GetWindowLong32(new HandleRef(this, this.Handle), GWL_STYLE));
        //    SetWindowLongPtr32(new HandleRef(this, this.Handle), GWL_STYLE, new HandleRef(null, (IntPtr)(style & ~WS_CLIPSIBLINGS)));

        //    base.OnLoad(e);
        //}
    }
}
