using HotelDomain.Model;

namespace HotelDomain.Data.Entities
{
    public class RoomBooking : IBookingTime
    {
        public Guid RoomBookingId { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }

        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
    }
}
