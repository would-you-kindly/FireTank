﻿using System;
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
            // Отменяем выделение
            if (e.KeyChar == (char)Keys.Escape)
            {
                dgvAlgorithm.ClearSelection();
            }

            // Удаляем выделенное действие
            if (e.KeyChar == (char)Keys.Back)
            {
                DeleteAction();
            }
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
    }
}
