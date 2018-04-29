using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
