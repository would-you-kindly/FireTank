using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class OpenFromFile : IOpener
    {
        private string filename;

        public OpenFromFile(string filename)
        {
            this.filename = filename;
        }

        public void OpenAlgorithm()
        {
            throw new NotImplementedException();
        }

        public void OpenMap()
        {
            throw new NotImplementedException();
        }

        public void SaveAlgorithm(ParallelAlgorithm algorithm)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, algorithm);
            }
        }
    }
}
