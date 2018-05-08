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
    public class DatabaseOpenSave : IOpenSave
    {
        private IRepository<AlgorithmModel> repository;

        private Guid id;
        private double result;
        private bool success;

        public DatabaseOpenSave(Guid id, double result, bool success)
        {
            this.repository = new AlgorithmRepository(Utilities.context);

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

            Utilities.context.Algorithms.Add(algorithm);
            Utilities.context.SaveChanges();
        }

        public ParallelAlgorithm OpenAlgorithm()
        {
            throw new NotImplementedException();
        }

        public void OpenMap()
        {
            throw new NotImplementedException();
        }
    }
}
