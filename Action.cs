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

        public Action()
        {
            commands = new Command[(int)Types.Count];

            commands[(int)Types.Move] = new MoveCommand(MoveCommand.Commands.None);
            commands[(int)Types.Charge] = new ChargeCommand(ChargeCommand.Commands.None);
            commands[(int)Types.Turret] = new TurretCommand(TurretCommand.Commands.None);
        }
    }
}
