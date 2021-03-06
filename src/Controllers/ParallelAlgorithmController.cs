﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FireSafety
{
    public class ParallelAlgorithmController
    {
        private static List<AlgorithmForm> algorithmForms;
        private static PlanForm planForm;

        public ParallelAlgorithmController(List<AlgorithmForm> algoForms, PlanForm planWindow)
        {
            algorithmForms = algoForms;
            planForm = planWindow;

            AttachEvents();
            // TODO: Почему-то если подписаться здесь ParallelAlgorithm.GetInstance().Loaded, то требует, чтобы этот класс тоже был сериализуемым
        }

        public static void ParallelAlgorithm_Cleared(object sender, ParallelAlgorithm.ClearEventArgs e)
        {
            planForm.dgvPlan.Rows.Clear();
            //planForm.dgvPlan.Rows.Add(1);
            planForm.dgvPlan.Rows[0].Cells[0].Value = 1;
        }

        public static void ParallelAlgorithmController_Saving(object sender, ParallelAlgorithm.SaveEventArgs e)
        {
            Plan plan = new Plan();

            for (int i = 0; i < planForm.dgvPlan.Rows.Count - 1; i++)
            {
                PlanItem planItem = new PlanItem();
                planItem.number = (int)planForm.dgvPlan.Rows[i].Cells[0].Value;

                for (int j = 1; j < planForm.dgvPlan.Rows[i].Cells.Count; j++)
                {
                    if (planForm.dgvPlan.Rows[i].Cells[j].Value != null)
                    {
                        planItem.tankActions.Add(planForm.dgvPlan.Rows[i].Cells[j].Value.ToString());
                    }
                    else
                    {
                        planItem.tankActions.Add("");
                    }
                }

                plan.items.Add(planItem);
            }

            ParallelAlgorithm.GetInstance().plan = plan;
        }

        public static void ParallelAlgorithmController_Reloaded(object sender, ParallelAlgorithm.ReloadEventArgs e)
        {
            foreach (AlgorithmForm form in algorithmForms)
            {
                // Очищаем цвета всех строк в таблице алгоритмов
                foreach (DataGridViewRow row in form.dgvAlgorithm.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            // Очищаем цвета всех строк в таблице плана
            foreach (DataGridViewRow row in planForm.dgvPlan.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
        }

        public static void ParallelAlgorithmController_NextActionPerforming(object sender, ParallelAlgorithm.PerformNextActionEventArgs e)
        {
            int i = 0;

            // Очищаем цвета всех строк в таблице плана
            foreach (DataGridViewRow row in planForm.dgvPlan.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

            foreach (AlgorithmForm form in algorithmForms)
            {
                // Очищаем цвета всех строк в таблице алгоритмов
                foreach (DataGridViewRow row in form.dgvAlgorithm.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                // Подсвечиваем текущее выполняющееся действие (если оно есть)
                try
                {
                    form.dgvAlgorithm.Rows[ParallelAlgorithm.GetInstance().currentAction - 1].DefaultCellStyle.BackColor = Color.Yellow;
                    object planItem = form.dgvAlgorithm.Rows[ParallelAlgorithm.GetInstance().currentAction - 1].Cells[4].Value;
                    if (planItem != null)
                    {
                        int index = int.Parse(((uint)planItem).ToString());
                        planForm.dgvPlan.Rows[index - 1].Cells[i + 1].Style.BackColor = Color.Yellow;
                    }
                }
                catch (Exception)
                {
                    // Ignore exception
                }

                i++;
            }
        }

        public static void ParallelAlgorithmController_AlgorithmExecuted(object sender, Algorithm.ExecuteEventArgs e)
        {
            int index = ParallelAlgorithm.GetInstance().algorithms.FindIndex(algo => algo == (Algorithm)sender);

            // Очищаем цвета всех строк в таблице
            foreach (DataGridViewRow row in algorithmForms[index].dgvAlgorithm.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private static void DgvAlgorithm_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Удаляем действие
            ParallelAlgorithm.GetInstance().DeleteAction((int)((DataGridView)sender).Tag, e.RowIndex);

            // Обновляем номера строк в таблице
            for (int i = e.RowIndex; i < ((DataGridView)sender).Rows.Count; i++)
            {
                ((DataGridView)sender).Rows[i].Cells[0].Value = i + 1;
            }
        }

        private static void DgvAlgorithm_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
            Command command = null;

            // Создаем команду в зависимости от измененного столбца
            switch (e.ColumnIndex)
            {
                // Команды исполнителей танка
                case 1:
                    command = new MoveCommand(Utilities.ToMoveCommand(row.Cells[1].Value.ToString()));
                    break;
                case 2:
                    command = new ChargeCommand(Utilities.ToChargeCommand(row.Cells[2].Value.ToString()));
                    break;
                case 3:
                    command = new TurretCommand(Utilities.ToTurretCommand(row.Cells[3].Value.ToString()));
                    break;
                // Пункт плана
                case 4:
                    ParallelAlgorithm.GetInstance().SetPlanItem((int)((DataGridView)sender).Tag, e.RowIndex, (uint)row.Cells[4].Value);
                    return;
                default:
                    return;
            }

            // Меняем соответствующую команду алгоритма
            if (command != null)
            {
                ParallelAlgorithm.GetInstance().ChangeCommand((int)((DataGridView)sender).Tag, e.RowIndex, e.ColumnIndex - 1, command);
            }
            else
            {
                throw new Exception("Команде алгоритма присвоено несуществующее значение.");
            }
        }

        public static void ParallelAlgorithmController_Loaded(object sender, ParallelAlgorithm.LoadEventArgs e)
        {
            DetachEvents();

            planForm.dgvPlan.Rows.Clear();
            //planForm.dgvPlan.Rows.Add(1);
            //planForm.dgvPlan.Rows[0].Cells[0].Value = 1;

            // Обновляем DataGridView в соответствии с алгоритмом
            for (int i = 0; i < algorithmForms.Count; i++)
            {
                // Очищаем таблицу перед добавлением строк
                algorithmForms[i].dgvAlgorithm.Rows.Clear();

                // Заполняем таблицу данными алгоритма
                for (int j = 0; j < ParallelAlgorithm.GetInstance().algorithms[i].actions.Count; j++)
                {
                    Action action = ParallelAlgorithm.GetInstance().algorithms[i].actions[j];

                    int number = j + 1;
                    string move = action.commands[(int)Action.Types.Move].ToString();
                    string charge = action.commands[(int)Action.Types.Charge].ToString();
                    string turret = action.commands[(int)Action.Types.Turret].ToString();
                    uint? planItem = action.planItem;

                    algorithmForms[i].dgvAlgorithm.Rows.Add(number, move, charge, turret, planItem != 0 ? planItem : null);
                }

                // Отменяем выделение
                algorithmForms[i].dgvAlgorithm.ClearSelection();
            }

            // Обновляем DataGridView плана в соответствии с алгоритмом
            for (int i = 0; i < ParallelAlgorithm.GetInstance().plan.items.Count; i++)
            {
                if (planForm.dgvPlan.Columns.Count == 2)
                {
                    planForm.dgvPlan.Rows.Add(ParallelAlgorithm.GetInstance().plan.items[i].number,
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[0]);
                }

                if (planForm.dgvPlan.Columns.Count == 3)
                {
                    planForm.dgvPlan.Rows.Add(ParallelAlgorithm.GetInstance().plan.items[i].number,
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[0],
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[1]);
                }

                if (planForm.dgvPlan.Columns.Count == 4)
                {
                    planForm.dgvPlan.Rows.Add(ParallelAlgorithm.GetInstance().plan.items[i].number,
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[0],
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[1],
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[2]);
                }

                if (planForm.dgvPlan.Columns.Count == 5)
                {
                    planForm.dgvPlan.Rows.Add(ParallelAlgorithm.GetInstance().plan.items[i].number,
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[0],
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[1],
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[2],
                        ParallelAlgorithm.GetInstance().plan.items[i].tankActions[3]);
                }

                //planForm.dgvPlan.Rows.Add(ParallelAlgorithm.GetInstance().plan.items.Count);
                //planForm.dgvPlan.Rows[i].Cells[0].Value = ParallelAlgorithm.GetInstance().plan.items[i].number;

                //for (int j = 0; j < ParallelAlgorithm.GetInstance().plan.items[i].tankActions.Count; j++)
                //{
                //    planForm.dgvPlan.Rows[i].Cells[j + 1].Value = ParallelAlgorithm.GetInstance().plan.items[i].tankActions[j];
                //}
            }

            AttachEvents();
        }

        public void ReloadAlgorithm()
        {
            ParallelAlgorithm.GetInstance().Reload();
        }

        public void RunAlgorithm()
        {
            ParallelAlgorithm.GetInstance().Run();
        }

        public void LoadAlgorithm(IOpenSave openSave)
        {
            ParallelAlgorithm.GetInstance().LoadAlgorithm(openSave);
        }

        public void SaveAlgorithm(IOpenSave openSave)
        {
            ParallelAlgorithm.GetInstance().SaveAlgorithm(openSave);
        }

        private static void DgvAlgorithm_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];

            // Собираем команды с добавленного DataGridViewRow
            MoveCommand.Commands moveCommand = Utilities.ToMoveCommand(row.Cells[1].Value.ToString());
            ChargeCommand.Commands chargeCommand = Utilities.ToChargeCommand(row.Cells[2].Value.ToString());
            TurretCommand.Commands turretCommand = Utilities.ToTurretCommand(row.Cells[3].Value.ToString());

            // Добавляем Action в соответствующий алгоритм танка
            Action action = new Action(moveCommand, chargeCommand, turretCommand);
            ParallelAlgorithm.GetInstance().InsertAction((int)((DataGridView)sender).Tag, action, e.RowIndex);
        }

        public void ClearAlgorithm()
        {
            ParallelAlgorithm.GetInstance().Clear();
        }

        public static void ParallelAlgorithmController_Cleared(object sender, ParallelAlgorithm.ClearEventArgs e)
        {
            DetachEvents();

            // Очищаем таблицы
            foreach (AlgorithmForm form in algorithmForms)
            {
                form.dgvAlgorithm.Rows.Clear();
            }

            AttachEvents();
        }

        private static void AttachEvents()
        {
            // Подключаем изменение действий при изменении строки в таблице
            foreach (AlgorithmForm form in algorithmForms)
            {
                form.dgvAlgorithm.RowsAdded += DgvAlgorithm_RowsAdded;
                form.dgvAlgorithm.CellValueChanged += DgvAlgorithm_CellValueChanged;
                form.dgvAlgorithm.RowsRemoved += DgvAlgorithm_RowsRemoved;
            }
        }

        private static void DetachEvents()
        {
            // Отключаем изменение действий при изменении строки в таблице, чтобы события не зациклились
            foreach (AlgorithmForm form in algorithmForms)
            {
                form.dgvAlgorithm.RowsAdded -= DgvAlgorithm_RowsAdded;
                form.dgvAlgorithm.CellValueChanged -= DgvAlgorithm_CellValueChanged;
                form.dgvAlgorithm.RowsRemoved -= DgvAlgorithm_RowsRemoved;
            }
        }

        public void StepAlgorithm()
        {
            ParallelAlgorithm.GetInstance().Step();
        }

        public void ClearErrors()
        {
            ParallelAlgorithm.GetInstance().errors.Clear();
        }

        public bool IsExecuted()
        {
            return ParallelAlgorithm.GetInstance().IsExecuted();
        }

        public double ComputeEfficiency(double mapWidth, double mapHeight, double initiallyBurningTrees, double totalTrees, double burnedTrees)
        {
            return ParallelAlgorithm.GetInstance().ComputeEfficiency(mapWidth, mapHeight, initiallyBurningTrees, totalTrees, burnedTrees);
        }

        public bool CheckErrors()
        {
            return ParallelAlgorithm.GetInstance().errors.Check();
        }

        public Errors GetErrors()
        {
            return ParallelAlgorithm.GetInstance().errors;
        }
    }
}