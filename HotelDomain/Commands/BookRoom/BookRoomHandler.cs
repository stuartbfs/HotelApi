using HotelDomain.Data.Repository;

namespace HotelDomain.Commands.BookRoom
{
    public class BookingHandler : ICommandHandler<BookRoomRequest, BookRoomResponse>
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public async Task<BookRoomResponse> Handle(BookRoomRequest request)
        {
            throw new NotImplementedException();
        }
    }
}