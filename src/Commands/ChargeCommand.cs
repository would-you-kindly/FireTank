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
            // Пополнение запасов воды (из озера)
            Refuel,
            // Перезарядка (подготовка к выстрелу)
            Charge,

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
                    return "Pressure x1";
                case Commands.PressureX2:
                    return "Pressure x2";
                case Commands.Refuel:
                    return "Refuel";
                case Commands.Charge:
                    return "Charge";
                case Commands.None:
                    return "None";
            }

            throw new NotImplementedException();
        }
    }
}
