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
            Shoot,
            Turret,

            Count
        }

        public Command[] tankCommands = new Command[(int)Types.Count];

        public Action()
        {
            tankCommands[(int)Types.Move] = new MoveCommand(MoveCommand.Commands.None);
            tankCommands[(int)Types.Shoot] = new ShootCommand(ShootCommand.Commands.None);
            tankCommands[(int)Types.Turret] = new TurretCommand(TurretCommand.Commands.None);
        }
    }
}
