using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FireSafety
{
    public class FileOpenSave : IOpenSave
    {
        private string filename;

        public FileOpenSave(string filename)
        {
            this.filename = filename;
        }

        public void SaveAlgorithm()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ParallelAlgorithm));
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, ParallelAlgorithm.GetInstance());
            }
        }

        public ParallelAlgorithm OpenAlgorithm()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(ParallelAlgorithm));
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                ParallelAlgorithm parallelAlgorithm = (ParallelAlgorithm)formatter.Deserialize(fs);

                // TODO: Почему-то грузит алгоритмы два раза
                parallelAlgorithm.algorithms.RemoveRange(0, parallelAlgorithm.algorithms.Count / 2);

                return parallelAlgorithm;
            }
        }

        public void OpenMap()
        {
            throw new NotImplementedException();
        }
    }
}
