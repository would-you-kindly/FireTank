﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class MapRepository : IRepository<MapModel>
    {
        private ModelContext context;
        private bool disposed = false;

        public MapRepository(ModelContext context)
        {
            this.context = context;
        }

        public void Create(MapModel item)
        {
            context.Maps.Add(item);
        }

        public MapModel Read(Guid id)
        {
            return context.Maps.Find(id);
        }

        public void Update(MapModel item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            MapModel map = context.Maps.Find(id);

            if (map != null)
            {
                context.Maps.Remove(map);
            }
        }

        public IEnumerable<MapModel> GetList()
        {
            return context.Maps;
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
