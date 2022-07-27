using HotelDomain.Model;

namespace HotelDomain.Data.Entities
{
    public class RoomBooking : IBookingTime
    {
        public Guid RoomBookingId { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; } = null!;
        
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; } = null!;

        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public int PartySize { get; set; }
    }
}
