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
        [NonSerialized]
        private static ParallelAlgorithm instance;

        public List<Algorithm> algorithms;

        private ParallelAlgorithm()
        {
            algorithms = new List<Algorithm>();

            // Создаем алгоритмы сразу для максимального количества танков
            for (int i = 0; i < Utilities.MAX_TANKS_COUNT; i++)
            {
                algorithms.Add(new Algorithm());
            }
        }

        public static ParallelAlgorithm GetInstance()
        {
            if (instance == null)
            {
                instance = new ParallelAlgorithm();
            }

            return instance;
        }

        public Algorithm this[int index]
        {
            get
            {
                return algorithms[index];
            }
            set
            {
                algorithms[index] = value;
            }
        }

        public void AddAction(int algorithmNumber, Action action)
        {

        }

        public void Load(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                instance = (ParallelAlgorithm)formatter.Deserialize(fs);
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
