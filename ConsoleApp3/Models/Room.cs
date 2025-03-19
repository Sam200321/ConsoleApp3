using System.Collections.Generic;

namespace HotellApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public required string Type { get; set; } // Enkelrum eller Dubbelrum
        public int MaxGuests { get; set; } // 1 för enkelrum, 2-4 för dubbelrum
        public decimal PricePerNight { get; set; }
        public List<Booking> Bookings { get; set; } = new();
    }
}



