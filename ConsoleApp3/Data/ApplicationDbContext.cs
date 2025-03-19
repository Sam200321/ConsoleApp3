using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using HotellApp.Models;
using System.IO;

namespace HotellApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // DbSet för dina entiteter
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // Konstruktor utan parametrar (kan tas bort om du inte behöver den längre)
        public ApplicationDbContext()
        {
        }

        // Konstruktor som tar DbContextOptions som parameter
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // OnConfiguring-metoden som konfigurerar anslutningen om den inte är konfigurerad redan
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // Sökväg till projektmappen
                    .AddJsonFile("appsettings.json") // Lägg till appsettings.json
                    .Build();

                // Hämta anslutningssträngen från appsettings.json
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString); // Konfigurera för att använda SQL Server
            }
        }
    } 

}

