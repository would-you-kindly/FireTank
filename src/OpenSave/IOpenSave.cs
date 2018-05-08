using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public interface IOpenSave
    {
        void SaveAlgorithm();
        ParallelAlgorithm OpenAlgorithm();
        void OpenMap();
    }
}
