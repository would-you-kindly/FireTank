using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FireSafety
{
    public class ParallelAlgorithmController
    {
        private static List<AlgorithmForm> algorithmForms;

        public ParallelAlgorithmController(List<AlgorithmForm> algoForms)
        {
            algorithmForms = algoForms;

            AttachEvents();
            // TODO: Почему-то если подписаться здесь ParallelAlgorithm.GetInstance().Loaded, то требует, чтобы этот класс тоже был сериализуемым
        }

        public static void ParallelAlgorithmController_Reloaded(object sender, ParallelAlgorithm.ReloadEventArgs e)
        {
            foreach (AlgorithmForm form in algorithmForms)
            {
                // Очищаем цвета всех строк в таблице
                foreach (DataGridViewRow row in form.dgvAlgorithm.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        public static void ParallelAlgorithmController_NextActionPerforming(object sender, ParallelAlgorithm.PerformNextActionEventArgs e)
        {
            foreach (AlgorithmForm form in algorithmForms)
            {
                // Очищаем цвета всех строк в таблице
                foreach (DataGridViewRow row in form.dgvAlgorithm.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                // Подсвечиваем текущее выполняющееся действие (если оно есть)
                try
                {
                    form.dgvAlgorithm.Rows[ParallelAlgorithm.GetInstance().currentAction].DefaultCellStyle.BackColor = Color.Yellow;
                }
                catch (Exception)
                {
                    // Ignore exception
                }
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

        public static void ParallelAlgorithmController_Executed(object sender, ParallelAlgorithm.ExecuteEventArgs e)
        {
            //foreach (AlgorithmForm form in algorithmForms)
            //{
            //    // Очищаем цвета всех строк
            //    foreach (DataGridViewRow row in form.dgvAlgorithm.Rows)
            //    {
            //        row.DefaultCellStyle.BackColor = Color.White;
            //    }
            //}

            //ParallelAlgorithm.GetInstance().Reload();
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
                case 1:
                    command = new MoveCommand(Utilities.ToMoveCommand(row.Cells[1].Value.ToString()));
                    break;
                case 2:
                    command = new ChargeCommand(Utilities.ToChargeCommand(row.Cells[2].Value.ToString()));
                    break;
                case 3:
                    command = new TurretCommand(Utilities.ToTurretCommand(row.Cells[3].Value.ToString()));
                    break;
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
                throw new Exception("Команде алгоритма присвоено несуществующее значение");
            }
        }

        public static void ParallelAlgorithmController_Loaded(object sender, ParallelAlgorithm.LoadEventArgs e)
        {
            DetachEvents();

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

                    algorithmForms[i].dgvAlgorithm.Rows.Add(number, move, charge, turret);
                }

                // Отменяем выделение
                algorithmForms[i].dgvAlgorithm.ClearSelection();
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
            ParallelAlgorithm.GetInstance().AddAction((int)((DataGridView)sender).Tag, action);
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
    }
}