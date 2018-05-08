using System;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    [XmlInclude(typeof(MoveCommand))]
    [XmlInclude(typeof(ChargeCommand))]
    [XmlInclude(typeof(TurretCommand))]
    public abstract class Command
    {
        public Command()
        { }

        public abstract void Execute(Tank tank);
    }
}
