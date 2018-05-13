using System;
using System.IO;
using System.Xml.Serialization;

namespace FireSafety
{
    public class DatabaseOpenSave : IOpenSave
    {
        private IRepository<AlgorithmModel> repository;

        private Guid id;
        private double result;
        private bool success;

        public DatabaseOpenSave(Guid id, double result = 0.0, bool success = false)
        {
            this.repository = new AlgorithmRepository(Utilities.GetInstance().context);

            this.id = id;
            this.result = result;
            this.success = success;
        }

        public void SaveAlgorithm()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ParallelAlgorithm));
            string xmlContent = string.Empty;
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ParallelAlgorithm.GetInstance());
                xmlContent = textWriter.ToString();
            }

            AlgorithmModel algorithm = new AlgorithmModel();
            algorithm.Id = id;
            algorithm.XmlContent = xmlContent;
            algorithm.Result = result;
            algorithm.Success = success;
            algorithm.CreationDate = DateTime.Now;
            algorithm.Map = Settings.GetInstance().currentMap;
            algorithm.User = Settings.GetInstance().currentUser;

            Utilities.GetInstance().context.Algorithms.Add(algorithm);
            Utilities.GetInstance().context.SaveChanges();
        }

        public ParallelAlgorithm OpenAlgorithm()
        {
            throw new NotImplementedException();
        }

        public Map OpenMap()
        {
            Map map = new Map();

            if (!map.LoadFromDatabase(id))
            {
                throw new Exception("Не удалось загрузить карту");
            }

            return map;
        }
    }
}
