using HotellApp.Data;
using HotellApp.Models;
using System;

namespace HotellApp.Services
{
    public class RoomService
    {
        // Metod för att skapa ett nytt rum och spara det i databasen
        public void CreateRoom()
        {
            Console.Write("Ange rumstyp (Enkelrum/Dubbelrum): ");
            string type = Console.ReadLine() ?? "Dubbelrum";

            Console.Write("Ange max antal gäster: ");
            int maxGuests = int.Parse(Console.ReadLine() ?? "2");

            Console.Write("Ange pris per natt: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? "1000");

            // Skapa ett nytt Room-objekt
            Room room = new Room
            {
                Type = type,
                MaxGuests = maxGuests,
                PricePerNight = price
            };

            // Spara rummet i databasen
            using (var context = new ApplicationDbContext())
            {
                context.Rooms.Add(room);  // Lägg till rummet i databasen
                int rowsAffected = context.SaveChanges();  // Spara ändringarna

                // Visa antal påverkade rader
                Console.WriteLine($"{rowsAffected} rad(er) påverkad(r).");
            }

            Console.WriteLine($"Rum {room.Type} skapat med ID {room.Id}.");
        }
    }
}
