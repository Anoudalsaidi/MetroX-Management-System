using System.Collections.Generic;

namespace MetroTicketSystem.Models
{
    // Represents train entity
    public class Train
    {
        // Primary Key
        public int Id { get; set; }

       
        public string Number { get; set; }

        public int Capacity { get; set; }

        // Navigation property
        public ICollection<Ticket> Tickets { get; set; }
    }
}