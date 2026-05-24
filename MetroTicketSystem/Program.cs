using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MetroTicketSystem.Data;
using MetroTicketSystem.Models;

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        // =========================
        // SEED DATA
        // =========================
        if (!context.Stations.Any())
        {
            var s1 = new Station { Name = "Ruwi", Location = "Muscat" };
            var s2 = new Station { Name = "Seeb", Location = "Muscat" };

            var t1 = new Train { Number = "T1", Capacity = 100 };
            var t2 = new Train { Number = "T2", Capacity = 120 };

            context.Stations.AddRange(s1, s2);
            context.Trains.AddRange(t1, t2);
            context.SaveChanges();

            context.Tickets.AddRange(
                new Ticket { PassengerName = "Ahmed", Price = 25, TravelDate = DateTime.Now, TrainId = t1.Id, StationId = s1.Id },
                new Ticket { PassengerName = "Sara", Price = 15, TravelDate = DateTime.Now, TrainId = t2.Id, StationId = s2.Id },
                new Ticket { PassengerName = "Ali", Price = 30, TravelDate = DateTime.Now, TrainId = t1.Id, StationId = s2.Id },
                new Ticket { PassengerName = "Omar", Price = 10, TravelDate = DateTime.Now, TrainId = t2.Id, StationId = s1.Id },
                new Ticket { PassengerName = "Nora", Price = 50, TravelDate = DateTime.Now, TrainId = t1.Id, StationId = s1.Id }
            );

            context.SaveChanges();
        }

        // =========================
        // ALL TICKETS (TABLE)
        // =========================
        Header("ALL TICKETS");

        var allTickets = context.Tickets
            .Include(t => t.Train)
            .Include(t => t.Station)
            .ToList();

        PrintTableHeader();

        foreach (var t in allTickets)
            PrintTableRow(t);

        PrintTableFooter();

        // =========================
        // PRICE FILTER
        // =========================
        Header("PRICE > 20");

        var priceFilter = context.Tickets
            .Include(t => t.Train)
            .Include(t => t.Station)
            .Where(t => t.Price > 20)
            .ToList();

        PrintTableHeader();

        foreach (var t in priceFilter)
            PrintTableRow(t);

        PrintTableFooter();

        // =========================
        // FIRST TICKET
        // =========================
        Header("FIRST TICKET (Ahmed)");

        var firstTicket = context.Tickets.FirstOrDefault(t => t.PassengerName == "Ahmed");
        PrintSingle(firstTicket);

        // =========================
        // COUNT
        // =========================
        Header("TOTAL TICKETS");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Tickets Count = {context.Tickets.Count()}");
        Console.ResetColor();

        // =========================
        // ORDER BY PRICE
        // =========================
        Header("ORDER BY PRICE DESC");

        var order = context.Tickets
            .Include(t => t.Train)
            .Include(t => t.Station)
            .OrderByDescending(t => t.Price)
            .ToList();

        PrintTableHeader();

        foreach (var t in order)
            PrintTableRow(t);

        PrintTableFooter();

        // =========================
        // INCLUDE VIEW
        // =========================
        Header("TICKETS DETAILS (RELATIONS)");

        var includeData = context.Tickets
            .Include(t => t.Train)
            .Include(t => t.Station)
            .ToList();

        PrintTableHeader();

        foreach (var t in includeData)
            PrintTableRow(t);

        PrintTableFooter();

        // =========================
        // BONUS
        // =========================
        Header("CHEAPEST TICKET");

        var cheapest = context.Tickets.OrderBy(t => t.Price).First();
        PrintSingle(cheapest);

        Header("MOST EXPENSIVE TICKET");

        var expensive = context.Tickets.OrderByDescending(t => t.Price).First();
        PrintSingle(expensive);

        Header("TICKETS PER TRAIN");

        var group = context.Tickets
            .Include(t => t.Train)
            .GroupBy(t => t.Train.Number)
            .Select(g => new { Train = g.Key, Count = g.Count() });

        foreach (var g in group)
            Console.WriteLine($"{g.Train} => {g.Count}");
    }

    // =======================
    //    UI METHODS
    // =======================

    static void Header(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n==============================");
        Console.WriteLine($"   >> {title}");
        Console.WriteLine("==============================\n");
        Console.ResetColor();
    }

    static void PrintTableHeader()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("---------------------------------------------------------------------");
        Console.WriteLine($"{"Passenger",-15}{"Train",-10}{"Station",-15}{"Price",-10}{"Date",-15}");
        Console.WriteLine("---------------------------------------------------------------------");
        Console.ResetColor();
    }

    static void PrintTableRow(Ticket t)
    {
        Console.WriteLine(
            $"{t.PassengerName,-15}" +
            $"{t.Train?.Number ?? "N/A",-10}" +
            $"{t.Station?.Name ?? "N/A",-15}" +
            $"{t.Price,-10}" +
            $"{t.TravelDate.ToShortDateString(),-15}"
        );
    }

    static void PrintTableFooter()
    {
        Console.WriteLine("---------------------------------------------------------------------\n");
    }

    static void PrintSingle(Ticket t)
    {
        if (t == null)
        {
            Console.WriteLine("No data found!");
            return;
        }

        Console.WriteLine("--------------------------------");
        Console.WriteLine($"Passenger : {t.PassengerName}");
        Console.WriteLine($"Price     : {t.Price}");
        Console.WriteLine("--------------------------------");
    }
}