using MetroTicketSystem.Data;
using MetroTicketSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetroTicketSystem.Services
{
    // Handles ticket business logic
    public class TicketService
    {
        private readonly AppDbContext _context;

        // Constructor Injection
        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        // Return all tickets with relations
        public List<Ticket> GetAllTickets()
        {
            return _context.Tickets
                .Include(t => t.Train)
                .Include(t => t.Station)
                .ToList();
        }
        // Add new ticket
        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        // Delete ticket by ID
        public void DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);

            // Check if ticket exists
            if (ticket == null)
                return;

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        }

        // Search tickets by passenger name
        public List<Ticket> SearchByPassenger(string name)
        {
            return _context.Tickets
                .Include(t => t.Train)
                .Include(t => t.Station)
                .Where(t => t.PassengerName.Contains(name))
                .ToList();
        }

        // Calculate total revenue
        public decimal GetRevenue()
        {
            return _context.Tickets.Sum(t => t.Price);
        }
    }
}
