using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class Plan
    {
        public List<Tuple<int, string, string>> ints = new List<Tuple<int, string, string>>();

        public Plan()
        {
            ints.Add(new Tuple<int, string, string>(1, "K-0", "L-2"));
            ints.Add(new Tuple<int, string, string>(3, "K-4", "L-8"));
            ints.Add(new Tuple<int, string, string>(4, "K-2", "L-5"));
            ints.Add(new Tuple<int, string, string>(5, "K-9", "L-6"));
        }
    }
}
