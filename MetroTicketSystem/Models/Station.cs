using System.Collections.Generic;

namespace MetroTicketSystem.Models
{
    // Represents metro station entity
    public class Station
    {
        // Primary Key
        public int Id { get; set; }

        // Station name
        public string Name { get; set; }

        // Station location
        public string Location { get; set; }

        // Navigation property
        public ICollection<Ticket> Tickets { get; set; }
    }
}