using MetroTicketSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetroTicketSystem.UI
{
    // Handles console interface design
    public static class ConsoleUI
    {
        // Project logo
        public static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(@"
 __  __ _____ _____ ____    ___  
|  \/  | ____|_   _|  _ \\ / _ \
| |\/| |  _|   | | | |_) | | | |
| |  | | |___  | | |  _ <| |_| |
|_|  |_|_____| |_| |_| \\_\ \__/");

            Console.ResetColor();
        }

        // Section title
        public static void Header(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\n================================");
            Console.WriteLine($" {title}");
            Console.WriteLine("================================\n");

            Console.ResetColor();
        }
        // Table Header
        public static void PrintTableHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine($"{"Passenger",-15}{"Train",-10}{"Station",-15}{"Price",-10}{"Date",-15}");
            Console.WriteLine("---------------------------------------------------------------------");

            Console.ResetColor();
        }

        // Print single row
        public static void PrintTableRow(Ticket t)
        {
            Console.WriteLine(
                $"{t.PassengerName,-15}" +
                $"{t.Train?.Number ?? "N/A",-10}" +
                $"{t.Station?.Name ?? "N/A",-15}" +
                $"{t.Price,-10}" +
                $"{t.TravelDate.ToShortDateString(),-15}"
            );
        }

        // Footer line
        public static void Footer()
        {
            Console.WriteLine("---------------------------------------------------------------------");
        }
    }
}
