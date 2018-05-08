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
    public partial class AlgorithmForm : Form
    {
        private Stopwatch clock = new Stopwatch();
        private bool keyPressed = false;

        public AlgorithmForm()
        {
            InitializeComponent();
        }

        // Блокируем кнопку закрытия окна
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

            // Задаем номер стобца
            int index = 0;
            switch (cb.Name)
            {
                case "cbMove":
                    index = 1;
                    break;
                case "cbCharge":
                    index = 2;
                    break;
                case "cbTurret":
                    index = 3;
                    break;
            }

            // Изменяем команды выделенного действия алгоритма
            if (dgvAlgorithm.SelectedCells.Count != 0)
            {
                dgvAlgorithm.Rows[dgvAlgorithm.SelectedCells[0].RowIndex].Cells[index].Value = cb.SelectedItem.ToString();
            }
            // Вставляем новое действие в конец алгоритма
            else
            {
                int number = dgvAlgorithm.RowCount + 1;
                string move = index == 1 ? cb.SelectedItem.ToString() : "None";
                string charge = index == 2 ? cb.SelectedItem.ToString() : "None";
                string turret = index == 3 ? cb.SelectedItem.ToString() : "None";
                dgvAlgorithm.Rows.Add(number, move, charge, turret);

                // Перемещаем таблицу вниз, чтобы были видны новые добавленные дейтсвия
                try
                {
                    dgvAlgorithm.FirstDisplayedScrollingRowIndex = dgvAlgorithm.Rows.Count - 1;
                }
                catch (Exception)
                {
                    // Ignore exception
                }
            }

            // Отменяем выделение и ставим фокус на таблице
            dgvAlgorithm.ClearSelection();
            dgvAlgorithm.Focus();
        }

        public void DeleteAction()
        {
            if (dgvAlgorithm.SelectedRows.Count != 0)
            {
                dgvAlgorithm.Rows.RemoveAt(dgvAlgorithm.SelectedRows[0].Index);
                dgvAlgorithm.ClearSelection();
                dgvAlgorithm.Focus();
            }
            else
            {
                MessageBox.Show("Выберите строку алгоритма, чтобы удалить ее.",
                    "Удаление строки алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ClearAlgorithm()
        {
            if (MessageBox.Show("Вы уверены, что хотите очистить алгоритм данного танка? Все несохраненные данные будут утеряны.",
                    "Очистка алгоритма", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                for (int i = dgvAlgorithm.Rows.Count - 1; i >= 0; i--)
                {
                    dgvAlgorithm.Rows.RemoveAt(i);
                }

                dgvAlgorithm.ClearSelection();
                dgvAlgorithm.Focus();
            }
        }

        private void Shortcut(ComboBox cb, string command)
        {
            // Задаем индекс -1, т.к. при выборе того же элемента событие SelectedItem не вызывается
            cb.SelectedIndex = -1;
            cb.SelectedItem = command;
        }

        private void dgvAlgorithm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyPressed)
            {
                return;
            }

            // Включаем таймер
            keyPressed = true;
            clock.Restart();

            // Отменяем выделение
            if (e.KeyCode == Settings.GetInstance().clearSelection)
            {
                dgvAlgorithm.ClearSelection();
            }

            // Удаляем выделенное действие
            if (e.KeyCode == Settings.GetInstance().deleteAction)
            {
                DeleteAction();
            }

            // Обрабатываем горячие клавиши добавления команд движения
            if (e.KeyCode == Settings.GetInstance().moveForward)
            {
                Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Forward));
            }

            if (e.KeyCode == Settings.GetInstance().moveBackward)
            {
                Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Backward));
            }

            if (e.KeyCode == Settings.GetInstance().moveForward45CW)
            {
                Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Forward45CW));
            }

            if (e.KeyCode == Settings.GetInstance().moveForward45CCW)
            {
                Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Forward45CCW));
            }

            if (e.KeyCode == Settings.GetInstance().moveBackward45CW)
            {
                Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Backward45CW));
            }

            if (e.KeyCode == Settings.GetInstance().moveBackward45CCW)
            {
                Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Backward45CCW));
            }

            if (e.KeyCode == Settings.GetInstance().none)
            {
                Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.None));
            }

            // Обрабатываем горячие клавиши добавления команд перезарядки
            if (e.KeyCode == Settings.GetInstance().chargeRefuel)
            {
                Shortcut(cbCharge, Utilities.ToChargeString(ChargeCommand.Commands.Refuel));
            }

            if (e.KeyCode == Settings.GetInstance().chargeCharge)
            {
                Shortcut(cbCharge, Utilities.ToChargeString(ChargeCommand.Commands.Charge));
            }

            // Обрабатываем горячие клавиши добавления команд турели
            if (e.KeyCode == Settings.GetInstance().turretUp)
            {
                Shortcut(cbTurret, Utilities.ToTurretString(TurretCommand.Commands.Up));
            }

            if (e.KeyCode == Settings.GetInstance().turretDown)
            {
                Shortcut(cbTurret, Utilities.ToTurretString(TurretCommand.Commands.Down));
            }

            if (e.KeyCode == Settings.GetInstance().turretShoot)
            {
                Shortcut(cbTurret, Utilities.ToTurretString(TurretCommand.Commands.Shoot));
            }
        }

        private void dgvAlgorithm_KeyUp(object sender, KeyEventArgs e)
        {
            // Выключаем таймер
            keyPressed = false;
            clock.Stop();

            // Обрабатываем короткое/долгое нажатие горячей клавиши для добавления разных команд движения
            if (e.KeyCode == Settings.GetInstance().moveRotateCW)
            {
                if (clock.ElapsedMilliseconds < Settings.GetInstance().timeToHold)
                {
                    Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Rotate45CW));
                }
                else
                {
                    Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Rotate90CW));
                }
            }

            if (e.KeyCode == Settings.GetInstance().moveRotateCCW)
            {
                if (clock.ElapsedMilliseconds < Settings.GetInstance().timeToHold)
                {
                    Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Rotate45CCW));
                }
                else
                {
                    Shortcut(cbMove, Utilities.ToMoveString(MoveCommand.Commands.Rotate90CCW));
                }
            }

            // Обрабатываем короткое/долгое нажатие горячей клавиши для добавления разных команд перезарядки
            if (e.KeyCode == Settings.GetInstance().chargePressure)
            {
                if (clock.ElapsedMilliseconds < Settings.GetInstance().timeToHold)
                {
                    Shortcut(cbCharge, Utilities.ToChargeString(ChargeCommand.Commands.PressureX1));
                }
                else
                {
                    Shortcut(cbCharge, Utilities.ToChargeString(ChargeCommand.Commands.PressureX2));
                }
            }

            // Обрабатываем короткое/долгое нажатие горячей клавиши для добавления разных команд турели
            if (e.KeyCode == Settings.GetInstance().turretRotateCW)
            {
                if (clock.ElapsedMilliseconds < Settings.GetInstance().timeToHold)
                {
                    Shortcut(cbTurret, Utilities.ToTurretString(TurretCommand.Commands.Rotate45CW));
                }
                else
                {
                    Shortcut(cbTurret, Utilities.ToTurretString(TurretCommand.Commands.Rotate90CW));
                }
            }

            if (e.KeyCode == Settings.GetInstance().turretRotateCCW)
            {
                if (clock.ElapsedMilliseconds < Settings.GetInstance().timeToHold)
                {
                    Shortcut(cbTurret, Utilities.ToTurretString(TurretCommand.Commands.Rotate45CCW));
                }
                else
                {
                    Shortcut(cbTurret, Utilities.ToTurretString(TurretCommand.Commands.Rotate90CCW));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = ParallelAlgorithm.GetInstance();
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        private void btnClearAlgorithm_Click(object sender, EventArgs e)
        {
            ClearAlgorithm();
        }
    }
}
