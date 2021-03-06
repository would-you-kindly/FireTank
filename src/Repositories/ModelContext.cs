﻿using System.Data.Entity;

namespace FireSafety
{
    public class ModelContext : DbContext
    {
        public ModelContext(string connectionString) :
            base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Настройка полей с помощью Fluent API
            modelBuilder.Entity<MapModel>().Property(c => c.XmlContent).HasColumnType("xml");
            modelBuilder.Entity<MapModel>().Ignore(c => c.XmlValueWrapper);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<AlgorithmModel> Algorithms { get; set; }
        public DbSet<MapModel> Maps { get; set; }
    }
}
