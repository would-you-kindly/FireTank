using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class AlgorithmRepository : IRepository<AlgorithmModel>
    {
        private ModelContext context;
        private bool disposed = false;

        public AlgorithmRepository(ModelContext context)
        {
            this.context = context;
        }

        public void Create(AlgorithmModel item)
        {
            context.Algorithms.Add(item);

            context.SaveChanges();
        }

        public AlgorithmModel Read(Guid id)
        {
            return context.Algorithms.Find(id);
        }

        public void Update(AlgorithmModel item)
        {
            context.Entry(item).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            AlgorithmModel algorithm = context.Algorithms.Find(id);

            if (algorithm != null)
            {
                context.Algorithms.Remove(algorithm);

                context.SaveChanges();
            }
        }

        public IEnumerable<AlgorithmModel> GetList()
        {
            return context.Algorithms.OrderBy(algorithm => algorithm.Result);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
