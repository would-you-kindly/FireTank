using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class ParallelAlgorithm
    {
        public List<Algorithm> Algorithms { get; set; }

        public ParallelAlgorithm()
        {
            Algorithms = new List<Algorithm>();

            for (int i = 0; i < Utilities.TANKS_COUNT; i++)
            {
                Algorithms.Add(new Algorithm());
            }
        }

        public Algorithm this[int index]
        {
            get
            {
                return Algorithms[index];
            }
            set
            {
                Algorithms[index] = value;
            }
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
