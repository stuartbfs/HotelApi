using HotelDomain.Data.Projections;

namespace HotelDomain.Commands.BookRoom
{
    public class BookRoomResponse
    {
        public BookRoomResponse(IEnumerable<BookingDetails> details)
        {
            Details = details.ToArray();
        }

        public BookingDetails[] Details { get; }
    }
}