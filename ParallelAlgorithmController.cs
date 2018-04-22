using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FireSafety
{
    public class ParallelAlgorithmController
    {
        public ParallelAlgorithmController(List<AlgorithmForm> algorithmForms)
        {
            foreach (AlgorithmForm form in algorithmForms)
            {
                form.dgvAlgorithm.RowsAdded += delegate (object sender, DataGridViewRowsAddedEventArgs e)
                {
                    DataGridViewRow row = form.dgvAlgorithm.Rows[e.RowIndex];

                    // Собираем команды с добавленного DataGridViewRow
                    MoveCommand.Commands moveCommand = Utilities.ToMoveCommand(row.Cells[1].Value.ToString());
                    ChargeCommand.Commands chargeCommand = Utilities.ToChargeCommand(row.Cells[2].Value.ToString());
                    TurretCommand.Commands turretCommand = Utilities.ToTurretCommand(row.Cells[3].Value.ToString());

                    // Добавляем Action в соответствующий алгоритм танка
                    Action action = new Action(moveCommand, chargeCommand, turretCommand);
                    ParallelAlgorithm.GetInstance().AddAction(form.formNumber, action);
                };

                form.dgvAlgorithm.CellValueChanged += delegate (object sender, DataGridViewCellEventArgs e)
                {
                    //DataGridViewRow row = form.dgvAlgorithm.Rows[e.RowIndex];

                    //// Собираем команды с добавленного DataGridViewRow
                    //MoveCommand.Commands moveCommand = Utilities.ToMoveCommand(row.Cells[1].Value.ToString());
                    //ChargeCommand.Commands chargeCommand = Utilities.ToChargeCommand(row.Cells[2].Value.ToString());
                    //TurretCommand.Commands turretCommand = Utilities.ToTurretCommand(row.Cells[3].Value.ToString());

                    //// Добавляем Action в соответствующий алгоритм танка
                    //Action action = new Action(moveCommand, chargeCommand, turretCommand);
                    //ParallelAlgorithm.GetInstance().AddAction(form.formNumber, action);
                };
            }
        }
    }
}