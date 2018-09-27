using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class PlanItem
    {
        public int number;
        public List<string> tankActions;

        public PlanItem()
        {
            number = 0;
            tankActions = new List<string>();
        }
    }
}
