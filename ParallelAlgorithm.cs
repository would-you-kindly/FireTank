using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

            for (int i = 0; i < Utilities.MAX_TANKS_COUNT; i++)
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

        public void Load(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                ParallelAlgorithm loadedParallelAlgorithm = (ParallelAlgorithm)formatter.Deserialize(fs);
                this.Algorithms = loadedParallelAlgorithm.Algorithms;
            }
        }
        
        public void Save(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, this);
            }
        }

        public void Execute()
        {
            // TODO: Контролируем конфликты
            throw new NotImplementedException();
        }

        public void Clear()
        {
            // TODO: Нужно ли чистить?????
            //Algorithms.Clear();
        }
    }
}
