using HotelDomain.Model;

namespace HotelDomain.Commands.BookRoom
{
    public class BookRoomRequest : IBookingTime
    {
        public Guid HotelId { get; }

        public string FirstName { get; }

        public string LastName { get; }
        
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }

        public string[] RoomTypes { get; set; }
    }
}