using System;

namespace MetroTicketSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string PassengerName { get; set; }
        public decimal Price { get; set; }
        public DateTime TravelDate { get; set; }

        // Foreign Keys
        public int TrainId { get; set; }
        public Train Train { get; set; }

        public int StationId { get; set; }
        public Station Station { get; set; }
    }
}