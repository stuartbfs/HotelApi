using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Commands.BookRoom
{
    public class BookRoomRequest : IRequest<BookRoomResponse>, IBookingTime
    {
        public Guid HotelId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public RoomBookingItem[] Rooms { get; }
    }

    public class RoomBookingItem
    {
        public string RoomType { get; set; }
        public int PartySize { get; set; }
    }
}