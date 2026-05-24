using System.Collections.Generic;

namespace MetroTicketSystem.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        // علاقة: Station -> Tickets
        public List<Ticket> Tickets { get; set; }
    }
}