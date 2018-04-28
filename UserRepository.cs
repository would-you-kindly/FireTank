using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class UserRepository : IRepository<UserModel>
    {
        private ModelContext context;
        private bool disposed = false;

        public UserRepository(ModelContext context)
        {
            this.context = context;
        }

        public void Create(UserModel item)
        {
            context.Users.Add(item);
        }

        public UserModel Read(Guid id)
        {
            return context.Users.Find(id);
        }

        public void Update(UserModel item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            UserModel user = context.Users.Find(id);

            if (user != null)
            {
                context.Users.Remove(user);
            }
        }

        public IEnumerable<UserModel> GetList()
        {
            return context.Users.OrderBy(user => user.Lastname);
        }

        public void Save()
        {
            context.SaveChanges();
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
