using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

            context.SaveChanges();
        }

        public UserModel Read(Guid id)
        {
            return context.Users.Find(id);
        }

        public void Update(UserModel item)
        {
            context.Entry(item).State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            UserModel user = context.Users.Find(id);

            if (user != null)
            {
                context.Users.Remove(user);

                context.SaveChanges();
            }
        }

        public IEnumerable<UserModel> GetList()
        {
            return context.Users.OrderBy(user => user.Lastname);
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
