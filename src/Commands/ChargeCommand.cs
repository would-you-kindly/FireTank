using System;
using System.Xml.Serialization;

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
            // Перезарядка (подготовка к выстрелу)
            Charge,
            // Пополнение запасов воды (из озера)
            Refuel,

            None
        }

        [XmlElement(Namespace = "ChargeCommand")]
        public Commands command;

        public ChargeCommand()
        {
        }

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
                    return Properties.Resources.ChargeCommandPressure1;
                case Commands.PressureX2:
                    return Properties.Resources.ChargeCommandPressure2;
                case Commands.Charge:
                    return Properties.Resources.ChargeCommandCharge;
                case Commands.Refuel:
                    return Properties.Resources.ChargeCommandRefuel;
                case Commands.None:
                    return Properties.Resources.ChargeCommandNone;
            }

            throw new Exception("Неверно задано название команды ChargeCommand.");
        }
    }
}
