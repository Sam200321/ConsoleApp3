using System;

namespace HotellApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public required Room Room { get; set; }
        public int CustomerId { get; set; }
        public required Customer Customer { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public bool Paid { get; set; } = false; // False vid skapande, ändras när faktura betalas
    }
}



