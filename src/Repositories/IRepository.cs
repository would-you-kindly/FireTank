using System;
using System.Collections.Generic;

namespace FireSafety
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetList();
        void Create(T item);
        T Read(Guid id);
        void Update(T item);
        void Delete(Guid id);
    }
}
