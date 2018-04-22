using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class ChargeCommand : Command
    {
        public enum Commands
        {
            Pressure,
            None
        }

        public Commands command;

        public ChargeCommand(Commands command)
        {
            this.command = command;
        }

        public override void Execute(Tank tank)
        {
            tank.ChargeCommand(command);
        }

        public override string ToString()
        {
            switch (command)
            {
                case Commands.Pressure:
                    return "Pressure";
                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();
        }
    }
}
