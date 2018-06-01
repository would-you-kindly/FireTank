using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FireSafety
{
    public partial class AlgorithmForm : Form
    {
        private Stopwatch clock;
        private bool keyPressed;

        public AlgorithmForm()
        {
            InitializeComponent();

            clock = new Stopwatch();
            keyPressed = false;
        }

        #region Методы класса
        private void InsertAction()
        {
            InsertActionForm insertActionForm = new InsertActionForm(dgvAlgorithm.Rows.Count);
            insertActionForm.ShowDialog();

            if (insertActionForm.DialogResult == DialogResult.OK)
            {
                InsertAction(insertActionForm.Number, insertActionForm.Action);
            }
        }

        private void BlockTankAlgorithm(object sender)
        {
            // Позволяем заблокировать алгоритм, если он не выполняется
            if (!ParallelAlgorithm.GetInstance().running)
            {
                if (((CheckBox)sender).Checked)
                {
                    ParallelAlgorithm.GetInstance()[(int)dgvAlgorithm.Tag].blocked = true;
                    ((CheckBox)sender).BackgroundImage = Properties.Resources.Block;
                }
                else
                {
                    ParallelAlgorithm.GetInstance()[(int)dgvAlgorithm.Tag].blocked = false;
                    ((CheckBox)sender).BackgroundImage = Properties.Resources.Unblock;
                }
            }
            else
            {
                MessageBox.Show("Чтобы заблокировать алгоритм, необходимо сначала остановить его.",
                    "Блокировка алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DeleteAction()
        {
            // Позволяем удалить строку, если алгоритм не выполняется
            if (!ParallelAlgorithm.GetInstance().running)
            {
                if (dgvAlgorithm.SelectedRows.Count != 0)
                {
                    dgvAlgorithm.Rows.RemoveAt(dgvAlgorithm.SelectedRows[0].Index);
                    dgvAlgorithm.Focus();
                }
                else
                {
                    MessageBox.Show("Выберите строку алгоритма, чтобы удалить ее.",
                        "Удаление строки алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Чтобы удалить действие алгоритма, необходимо сначала остановить его.",
                    "Удаление строки алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ClearTankAlgorithm()
        {
            // Позволяем очистить алгоритм, если он не выполняется
            if (!ParallelAlgorithm.GetInstance().running)
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
            else
            {
                MessageBox.Show("Чтобы очистить алгоритм, необходимо сначала остановить его.",
                    "Очистка алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void InsertAction(int number, Action action)
        {
            if (!ParallelAlgorithm.GetInstance().running)
            {
                dgvAlgorithm.Rows.Insert(number, number + 1, action.commands[0].ToString(),
                    action.commands[1].ToString(), action.commands[2].ToString());

                // Перемещаем таблицу вниз, чтобы были видны новые добавленные дейтсвия
                try
                {
                    dgvAlgorithm.FirstDisplayedScrollingRowIndex = dgvAlgorithm.Rows.Count - 1;
                }
                catch (Exception)
                {
                    // Ignore exception
                }

                // Пересчитываем номера строк таблицы
                for (int i = 0; i < dgvAlgorithm.Rows.Count; i++)
                {
                    dgvAlgorithm.Rows[i].Cells[0].Value = i + 1;
                }

                // Отменяем выделение и ставим фокус на таблице
                dgvAlgorithm.ClearSelection();
                dgvAlgorithm.Focus();
            }
            else
            {
                MessageBox.Show("Чтобы именить команды алгоритма, необходимо сначала остановить его.",
                    "Изменение команд алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void SetCommand(ComboBox cb)
        {
            if (cb.SelectedIndex == -1)
            {
                return;
            }

            if (!ParallelAlgorithm.GetInstance().running)
            {
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
                    string move = index == 1 ? cb.SelectedItem.ToString() : "Бездействие";
                    string charge = index == 2 ? cb.SelectedItem.ToString() : "Бездействие";
                    string turret = index == 3 ? cb.SelectedItem.ToString() : "Бездействие";
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
            else
            {
                MessageBox.Show("Чтобы именить команды алгоритма, необходимо сначала остановить его.",
                    "Изменение команд алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Shortcut(ComboBox cb, string command)
        {
            // Задаем индекс -1, т.к. при выборе того же элемента событие SelectedItem не вызывается
            cb.SelectedIndex = -1;
            cb.SelectedItem = command;
        }
        #endregion

        #region Обработчики событий
        private void cbMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommand((ComboBox)sender);
        }

        private void cbCharge_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommand((ComboBox)sender);
        }

        private void cbTurret_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCommand((ComboBox)sender);
        }

        private void btnInsertAction_Click(object sender, EventArgs e)
        {
            InsertAction();
        }

        private void chbBlocked_CheckedChanged(object sender, EventArgs e)
        {
            BlockTankAlgorithm(sender);
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        private void btnClearAlgorithm_Click(object sender, EventArgs e)
        {
            ClearTankAlgorithm();
        }

        private void AlgorithmForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
            }

            Visible = false;
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
            // Очищаем алгоритм танка
            if (e.KeyCode == Settings.GetInstance().clearTankAlgorithm)
            {
                ClearTankAlgorithm();
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
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            var t = ParallelAlgorithm.GetInstance();
        }
    }
}
