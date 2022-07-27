using HotelDomain.Data.Repository;
using MediatR;

namespace HotelDomain.Commands.BookRoom
{
    public class BookingHandler : IRequestHandler<BookRoomRequest, BookRoomResponse>
    {
        private readonly IBookingRepository _repository;

        public BookingHandler(IBookingRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<BookRoomResponse> Handle(BookRoomRequest request, CancellationToken cancellationToken)
        {
            var booking = await _repository.BookRoom(
                request.HotelId, 
                request.FirstName, 
                request.LastName,
                request.CheckIn, 
                request.CheckOut, 
                request.RoomType, 
                request.PartySize);

            return new BookRoomResponse
            {
                BookingRef = booking.BookingNumber.ToString("D8")
            };
        }
    }
}