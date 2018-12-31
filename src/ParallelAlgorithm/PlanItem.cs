using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    public class PlanItem
    {
        public int number;
        //[XmlArray("TankActions"), XmlArrayItem(typeof(string), ElementName = "TankAction")]
        public List<string> tankActions;

        public PlanItem()
        {
            number = 0;
            tankActions = new List<string>();
        }
    }
}
