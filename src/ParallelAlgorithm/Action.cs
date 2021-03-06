﻿using System;
using System.Xml.Serialization;

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

        [XmlArray("Commands"), XmlArrayItem(typeof(Command), ElementName = "Command")]
        public Command[] commands;
        public uint planItem;

        public Action()
        {

        }

        public Action(MoveCommand.Commands moveCommand = MoveCommand.Commands.None,
            ChargeCommand.Commands chargeCommand = ChargeCommand.Commands.None,
            TurretCommand.Commands turretCommand = TurretCommand.Commands.None)
        {
            commands = new Command[(int)Types.Count];

            commands[(int)Types.Move] = new MoveCommand(moveCommand);
            commands[(int)Types.Charge] = new ChargeCommand(chargeCommand);
            commands[(int)Types.Turret] = new TurretCommand(turretCommand);
        }
    }
}
