using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using TollBoothManagementSystem.Core.Features.General;
using TollBoothManagementSystem.Core.Features.Infrastructure.Model;
using TollBoothManagementSystem.Core.Features.TransactionManagement.Model;
using TollBoothManagementSystem.Core.Features.UserManagement.Model;

namespace TollBoothManagementSystem.Core.Persistence
{
    public class DatabaseContext : DbContext
    {
        public string DbPath { get; }

        // General
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Location> Locations { get; set; }

        // Infrastructure
        public DbSet<FaultReport> FaultReports { get; set; }
        public DbSet<TollBooth> TollBooths { get; set; }
        public DbSet<TollStation> TollStations { get; set; }

        // Transaction Management
        public DbSet<ElectronicTollCollection> ElectronicTollCollections { get; set; }
        public DbSet<ETCPayment> ETCPayments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<RoadToll> RoadTolls { get; set; }
        public DbSet<RoadTollPayment> RoadTollPayments { get; set; }
        public DbSet<RoadTollPrice> RoadTollPrices { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionInfo> SectionInfos { get; set; }

        // User Management
        public DbSet<User> Users { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Referent> Referents { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        

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
