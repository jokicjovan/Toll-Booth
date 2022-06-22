using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace TollBooth.Core.Persistence
{
    public class DatabaseContext : DbContext
    {
        public string DbPath { get; }

        public DatabaseContext()
        {
            var folder = Directory.GetCurrentDirectory();
            DbPath = Path.Join(folder, "Core/Persistence");
            DbPath = Path.Join(DbPath, "tollbooth.db");
        }

        public DatabaseContext(int dummyArg)
        {
            var folder = Directory.GetCurrentDirectory();
            DbPath = Path.Join(folder, "..\\..\\..\\Core/Persistence");
            DbPath = Path.Join(DbPath, "tollbooth.db");
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            var folder = Environment.SpecialFolder.Desktop;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "tollbooth.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseLazyLoadingProxies().UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
