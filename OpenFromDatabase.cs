using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class OpenFromDatabase : IOpener
    {
        private IRepository<AlgorithmModel> repository;
        private Guid id;

        public OpenFromDatabase(Guid id)
        {
            ModelContext context = new ModelContext(Settings.GetInstance().connectionString);
            this.repository = new AlgorithmRepository(context);

            this.id = id;
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
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, this);
                bytes = ms.ToArray();
            }

            // TODO: Стремно пока тут
            AlgorithmModel algorithmModel = new AlgorithmModel();
            algorithmModel.Id = Guid.NewGuid();
            algorithmModel.Bytes = bytes;
            algorithmModel.Result = /*ComputeEfficiency();*/ 10.0; // TODO: !!!
            algorithmModel.CreationDate = DateTime.Now;
            algorithmModel.Success = true; // TODO: !!!
            UserRepository r = new UserRepository(new ModelContext(Settings.GetInstance().connectionString));
            algorithmModel.User = r.Read(Settings.currentUser);
            //algorithm.Map = 

            repository.Create(algorithmModel);
            repository.Save();
        }
    }
}
