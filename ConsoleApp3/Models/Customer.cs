using System.Collections.Generic;

namespace HotellApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public List<Booking> Bookings { get; set; } = new();
    }
}


