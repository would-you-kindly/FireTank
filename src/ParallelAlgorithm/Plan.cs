using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    public class Plan
    {
        [XmlArray("PlanItems"), XmlArrayItem(typeof(PlanItem), ElementName = "PlanItems")]
        public List<PlanItem> items;

        public Plan()
        {
            items = new List<PlanItem>();
        }
    }
}
