using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetList();
        void Create(T item);
        T Read(Guid id);
        void Update(T item);
        void Delete(Guid id);
        void Save();
    }
}
