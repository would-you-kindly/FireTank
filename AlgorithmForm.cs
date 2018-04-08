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
        private Algorithm _algorithm;

        public AlgorithmForm(Algorithm algorithm)
        {
            InitializeComponent();

            _algorithm = algorithm;
        }

        private void cbShootCommandsCommands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbMoveCommands.SelectedItem != null)
            {
                lbMoveCommands.Items.Insert(lbMoveCommands.SelectedIndex, cbMove.SelectedItem.ToString());
                lbMoveCommands.Items.RemoveAt(lbMoveCommands.SelectedIndex);
            }
            else
            {
                lbMoveCommands.Items.Add(cbMove.SelectedItem.ToString());
                lbShootCommands.Items.Add("None");
                lbTurretCommands.Items.Add("None");
            }

            cbMove.SelectedText = null;
        }

        private void cbShoot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbShootCommands.SelectedItem != null)
            {
                lbShootCommands.Items.Insert(lbShootCommands.SelectedIndex, cbShoot.SelectedItem.ToString());
                lbShootCommands.Items.RemoveAt(lbShootCommands.SelectedIndex);
            }
            else
            {
                lbMoveCommands.Items.Add("None");
                lbShootCommands.Items.Add(cbShoot.SelectedItem.ToString());
                lbTurretCommands.Items.Add("None");
            }

            cbShoot.SelectedText = null;
        }

        private void cbTurret_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbTurretCommands.SelectedItem != null)
            {
                lbTurretCommands.Items.Insert(lbTurretCommands.SelectedIndex, cbTurret.SelectedItem.ToString());
                lbTurretCommands.Items.RemoveAt(lbTurretCommands.SelectedIndex);
            }
            else
            {
                lbMoveCommands.Items.Add("None");
                lbShootCommands.Items.Add("None");
                lbTurretCommands.Items.Add(cbTurret.SelectedItem.ToString());
            }

            cbTurret.SelectedText = null;
        }

        private void btnExecuteAlgorithm_Click(object sender, EventArgs e)
        {
            _algorithm.actions.Clear();

            List<Action> listActions = new List<Action>();
            for (int i = 0; i < lbMoveCommands.Items.Count; i++)
            {
                listActions.Add(new Action());
            }

            for (int i = 0; i < lbMoveCommands.Items.Count; i++)
            {
                switch (lbMoveCommands.Items[i].ToString())
                {
                    case "Forward":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Forward);
                        break;
                    case "Backward":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Backward);
                        break;
                    case "Rotate 90 CW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate90CW);
                        break;
                    case "Rotate 90 CCW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate90CCW);
                        break;
                    case "Rotate 45 CW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate45CW);
                        break;
                    case "Rotate 45 CCW":
                        listActions[i].tankCommands[(int)Action.Types.Move] = new MoveCommand(MoveCommand.Commands.Rotate45CCW);
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < lbShootCommands.Items.Count; i++)
            {
                switch (lbShootCommands.Items[i].ToString())
                {
                    case "Increase water pressure":
                        listActions[i].tankCommands[(int)Action.Types.Shoot] = new ShootCommand(ShootCommand.Commands.IncreaseWaterPressure);
                        break;
                    case "Shoot":
                        listActions[i].tankCommands[(int)Action.Types.Shoot] = new ShootCommand(ShootCommand.Commands.Shoot);
                        break;
                    default:
                        break;
                }
            }

            for (int i = 0; i < lbTurretCommands.Items.Count; i++)
            {
                switch (lbTurretCommands.Items[i].ToString())
                {
                    case "Rotate 90 CW":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate90CW);
                        break;
                    case "Rotate 90 CCW":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Rotate90CCW);
                        break;
                    case "Up":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Up);
                        break;
                    case "Down":
                        listActions[i].tankCommands[(int)Action.Types.Turret] = new TurretCommand(TurretCommand.Commands.Down);
                        break;
                    default:
                        break;
                }
            }

            Queue<Action> actions = new Queue<Action>();
            foreach (Action action in listActions)
            {
                actions.Enqueue(action);
            }

            _algorithm.actions = actions;
            Game.executing = true;
        }
    }
}
