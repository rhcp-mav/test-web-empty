using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace test_web_empty
{
    public class DataContext : DbContext
    {
        public DbSet<TCameraGroups> CameraGroups { get; set; }
        public DbSet<TCameras> Cameras { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            //Database.EnsureCreated();   // create a database on the first call
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TCameras>()
            //    .HasOne(g => g.CameraGroup)
            //    .WithMany(c => c.Cameras)
            //    .OnDelete(DeleteBehavior.SetNull); // off cascade delete
        }
    }
}
