using MetroTicketSystem.Data;
using MetroTicketSystem.Models;
using MetroTicketSystem.Seed;
using MetroTicketSystem.Services;
using MetroTicketSystem.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // Create database context
        using var context = new AppDbContext();

        // Seed initial data
        DbSeeder.Seed(context);

        // Create service object
        var ticketService = new TicketService(context);

        // Main application loop
        while (true)
        {
            Console.Clear();

            // Display logo
            ConsoleUI.Logo();

            // Display menu
            Console.WriteLine("1. View Tickets");
            Console.WriteLine("2. Add Ticket");
            Console.WriteLine("3. Search Ticket");
            Console.WriteLine("4. Delete Ticket");
            Console.WriteLine("5. Revenue Report");
            Console.WriteLine("0. Exit");

            Console.Write("\nChoose Option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                // View all tickets
                case "1":

                    Console.Clear();

                    ConsoleUI.Header("ALL TICKETS");

                    var tickets = ticketService.GetAllTickets();

                    ConsoleUI.PrintTableHeader();

                    foreach (var t in tickets)
                        ConsoleUI.PrintTableRow(t);

                    ConsoleUI.Footer();

                    break;

                // Add new ticket
                case "2":

                    Console.Clear();

                    ConsoleUI.Header("ADD NEW TICKET");

                    Console.Write("Passenger Name: ");
                    var name = Console.ReadLine();

                    // Validate input
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Invalid name!");
                        break;
                    }

                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    // Create ticket object
                    var newTicket = new Ticket
                    {
                        PassengerName = name,
                        Price = price,
                        TravelDate = DateTime.Now,
                        TrainId = 1,
                        StationId = 1
                    };

                    // Save ticket
                    ticketService.AddTicket(newTicket);

                    Console.WriteLine("Ticket Added Successfully!");

                    break;

                // Search ticket
                case "3":

                    Console.Clear();

                    ConsoleUI.Header("SEARCH TICKET");

                    Console.Write("Passenger Name: ");

                    var search = Console.ReadLine();

                    var results = ticketService.SearchByPassenger(search);

                    ConsoleUI.PrintTableHeader();

                    foreach (var t in results)
                        ConsoleUI.PrintTableRow(t);

                    ConsoleUI.Footer();

                    break;

                // Delete ticket
                case "4":

                    Console.Clear();

                    ConsoleUI.Header("DELETE TICKET");

                    Console.Write("Enter Ticket ID: ");

                    int id = int.Parse(Console.ReadLine());

                    ticketService.DeleteTicket(id);

                    Console.WriteLine("Ticket Deleted Successfully!");

                    break;

                // Revenue report
                case "5":

                    Console.Clear();

                    ConsoleUI.Header("REVENUE REPORT");

                    var revenue = ticketService.GetRevenue();

                    Console.WriteLine($"Total Revenue = {revenue}");

                    break;

                // Exit application
                case "0":
                    return;
            }
            Console.WriteLine("\nPress Any Key To Continue...");
            Console.ReadKey();
        }
    }
}
        