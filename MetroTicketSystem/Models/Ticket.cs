using System;

namespace MetroTicketSystem.Models
{
    // Represents ticket entity
    public class Ticket
    {
        // Primary Key
        public int Id { get; set; }


        public string PassengerName { get; set; }

       
        public decimal Price { get; set; }

        public DateTime TravelDate { get; set; }

        // Foreign Key for Train
        public int TrainId { get; set; }

        // Navigation Property
        public Train Train { get; set; }

        // Foreign Key for Station
        public int StationId { get; set; }

        // Navigation Property
        public Station Station { get; set; }
    }
}