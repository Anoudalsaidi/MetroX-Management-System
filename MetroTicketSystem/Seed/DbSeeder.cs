using MetroTicketSystem.Data;
using MetroTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetroTicketSystem.Seed
{
    // Seeds initial database data
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // Prevent duplicate seeding
            if (context.Stations.Any())
                return;

            // Create stations
            var s1 = new Station { Name = "Ruwi", Location = "Muscat" };
            var s2 = new Station { Name = "Seeb", Location = "Muscat" };

            // Create trains
            var t1 = new Train { Number = "T1", Capacity = 100 };
            var t2 = new Train { Number = "T2", Capacity = 120 };

            // Add stations and trains
            context.Stations.AddRange(s1, s2);
            context.Trains.AddRange(t1, t2);

            // Save changes to database
            context.SaveChanges();

            // Add sample tickets
            context.Tickets.AddRange(
                new Ticket
                {
                    PassengerName = "Ahmed",
                    Price = 25,
                    TravelDate = DateTime.Now,
                    TrainId = t1.Id,
                    StationId = s1.Id
                },
                 new Ticket
                 {
                     PassengerName = "Sara",
                     Price = 15,
                     TravelDate = DateTime.Now,
                     TrainId = t2.Id,
                     StationId = s2.Id
                 }
            );

            // Save tickets
            context.SaveChanges();
        }
    }
}
