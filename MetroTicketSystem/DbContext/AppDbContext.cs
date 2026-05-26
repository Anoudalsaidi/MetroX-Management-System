using Microsoft.EntityFrameworkCore;
using MetroTicketSystem.Models;

namespace MetroTicketSystem.Data
{
    // Database context class
    public class AppDbContext : DbContext
    {
        // Tickets table
        public DbSet<Ticket> Tickets { get; set; }

        // Trains table
        public DbSet<Train> Trains { get; set; }

        // Stations table
        public DbSet<Station> Stations { get; set; }

        // Configure SQL Server connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=MetroXDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
