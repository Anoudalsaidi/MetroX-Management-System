using Microsoft.EntityFrameworkCore;
using MetroTicketSystem.Models;

namespace MetroTicketSystem.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
 "Server=(localdb)\\MSSQLLocalDB;Database=MetroDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    }
