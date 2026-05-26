using System.Collections.Generic;

namespace MetroTicketSystem.Models
{
    // Represents train entity
    public class Train
    {
        // Primary Key
        public int Id { get; set; }

        // Train number
        public string Number { get; set; }

        // Maximum train capacity
        public int Capacity { get; set; }

        // Navigation property
        public ICollection<Ticket> Tickets { get; set; }
    }
}