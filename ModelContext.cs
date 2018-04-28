using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class ModelContext : DbContext
    {
        public ModelContext(string connectionString) :
            base(connectionString)
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AlgorithmModel> Algorithms { get; set; }
        public DbSet<MapModel> Maps { get; set; }
    }
}
