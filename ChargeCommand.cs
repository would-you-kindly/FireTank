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
            // Увеличение давления воды (дальности стрельбы)
            PressureX1,
            PressureX2,
            // Пополнение запасов воды (из озера)
            Refuel,
            // Перезарядка (подготовка к выстрелу)
            Charge1,
            Charge2,

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
                case Commands.PressureX1:
                    return "Pressure x1";
                case Commands.PressureX2:
                    return "Pressure x2";
                case Commands.Refuel:
                    return "Refuel";
                case Commands.Charge1:
                    return "Charge 1";
                case Commands.Charge2:
                    return "Charge 2";
                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();
        }
    }
}
