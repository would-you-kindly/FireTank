using System;
using System.IO;
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
                ParallelAlgorithm.GetInstance().Clear();
                ParallelAlgorithm parallelAlgorithm = (ParallelAlgorithm)formatter.Deserialize(fs);

                // TODO: Почему-то грузит алгоритмы два раза
                parallelAlgorithm.algorithms.RemoveRange(0, parallelAlgorithm.algorithms.Count / 2);

                return parallelAlgorithm;
            }
        }

        public Map OpenMap()
        {
            Map map = new Map();

            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (!map.Load(sr.ReadToEnd()))
                    {
                        throw new Exception("Не удалось загрузить карту.");
                    }
                }
            }

            // TODO: Это вроде не здесь должно быть
            Settings.GetInstance().UnsetCurrentMap();

            return map;
        }
    }
}
