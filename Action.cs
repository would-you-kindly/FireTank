using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class Action
    {
        public enum Types
        {
            Move = 0,
            Charge,
            Turret,

            Count
        }

        public Command[] commands;

        public Action(MoveCommand.Commands moveCommand = MoveCommand.Commands.None,
            ChargeCommand.Commands chargeCommand = ChargeCommand.Commands.None,
            TurretCommand.Commands turretCommand = TurretCommand.Commands.None)
        {
            commands = new Command[(int)Types.Count];

            commands[(int)Types.Move] = new MoveCommand(moveCommand);
            commands[(int)Types.Charge] = new ChargeCommand(chargeCommand);
            commands[(int)Types.Turret] = new TurretCommand(turretCommand);
        }

        public Action(MoveCommand moveCommand, ChargeCommand chargeCommand, TurretCommand turretCommand)
        {
            commands = new Command[(int)Types.Count];

            commands[(int)Types.Move] = moveCommand;
            commands[(int)Types.Charge] = chargeCommand;
            commands[(int)Types.Turret] = turretCommand;
        }
    }
}
