using System;
using System.Collections.Generic;
using HotellApp.Models;

class Program
{
    static List<Room> rooms = new();
    static List<Customer> customers = new();
    static List<Booking> bookings = new();

    static void Main()
    {
        Console.WriteLine("Välkommen till HotellApp!");

        while (true)
        {
            Console.WriteLine("\nVälj ett alternativ:");
            Console.WriteLine("1. Skapa rum");
            Console.WriteLine("2. Lägg till kund");
            Console.WriteLine("3. Skapa bokning");
            Console.WriteLine("4. Visa alla bokningar");
            Console.WriteLine("5. Avsluta");

            Console.Write("Ditt val: ");
            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    CreateRoom();
                    break;
                case "2":
                    CreateCustomer();
                    break;
                case "3":
                    CreateBooking();
                    break;
                case "4":
                    ShowBookings();
                    break;
                case "5":
                    Console.WriteLine("Programmet avslutas...");
                    return;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");
                    break;
            }
        }
    }

    static void CreateRoom()
    {
        Console.Write("Ange rumstyp (Enkelrum/Dubbelrum): ");
        string type = Console.ReadLine() ?? "Dubbelrum";

        Console.Write("Ange max antal gäster: ");
        int maxGuests = int.Parse(Console.ReadLine() ?? "2");

        Console.Write("Ange pris per natt: ");
        decimal price = decimal.Parse(Console.ReadLine() ?? "1000");

        Room room = new() { Id = rooms.Count + 1, Type = type, MaxGuests = maxGuests, PricePerNight = price };
        rooms.Add(room);

        Console.WriteLine($"Rum {room.Type} skapat med ID {room.Id}.");
    }

    static void CreateCustomer()
    {
        Console.Write("Ange kundens namn: ");
        string name = Console.ReadLine() ?? "Okänd";

        Console.Write("Ange kundens e-post: ");
        string email = Console.ReadLine() ?? "unknown@example.com";

        Console.Write("Ange kundens telefonnummer: ");
        string phone = Console.ReadLine() ?? "000000000";

        Customer customer = new() { Id = customers.Count + 1, Name = name, Email = email, Phone = phone };
        customers.Add(customer);

        Console.WriteLine($"Kund {customer.Name} skapad med ID {customer.Id}.");
    }

    static void CreateBooking()
    {
        Console.Write("Ange kund-ID: ");
        int customerId = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ange rum-ID: ");
        int roomId = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ange incheckningsdatum (YYYY-MM-DD): ");
        DateTime checkIn = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.ToString());

        Console.Write("Ange utcheckningsdatum (YYYY-MM-DD): ");
        DateTime checkOut = DateTime.Parse(Console.ReadLine() ?? DateTime.Today.AddDays(1).ToString());

        Customer? customer = customers.Find(c => c.Id == customerId);
        Room? room = rooms.Find(r => r.Id == roomId);

        if (customer == null || room == null)
        {
            Console.WriteLine("Kund eller rum hittades inte!");
            return;
        }

        Booking booking = new() { Id = bookings.Count + 1, RoomId = roomId, Room = room, CustomerId = customerId, Customer = customer, CheckInDate = checkIn, CheckOutDate = checkOut, Paid = false };
        bookings.Add(booking);

        Console.WriteLine($"Bokning skapad för {customer.Name} i rum {room.Type} från {checkIn.ToShortDateString()} till {checkOut.ToShortDateString()}.");
    }

    static void ShowBookings()
    {
        Console.WriteLine("\nAlla bokningar:");
        if (bookings.Count == 0)
        {
            Console.WriteLine("Inga bokningar ännu.");
            return;
        }

        foreach (var booking in bookings)
        {
            Console.WriteLine($"Bokning ID: {booking.Id}, Kund: {booking.Customer.Name}, Rum: {booking.Room.Type}, Incheckning: {booking.CheckInDate.ToShortDateString()}, Utcheckning: {booking.CheckOutDate.ToShortDateString()}, Betald: {(booking.Paid ? "Ja" : "Nej")}");
        }
    }
}
