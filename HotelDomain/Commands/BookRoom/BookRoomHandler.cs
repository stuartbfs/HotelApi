using HotelDomain.Data.Repository;
using HotelDomain.Exceptions;
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
            if (!await _repository.HotelExists(request.HotelId))
            {
                throw new NotFoundException("Unknown hotel");
            }

            var booking = await _repository.BookRoom(
                request.HotelId, 
                request.FirstName, 
                request.LastName,
                request.CheckIn, 
                request.CheckOut, 
                request.RoomType, 
                request.PartySize);

            var bookingDetails = await _repository.GetBooking(booking.BookingNumber);

            return new BookRoomResponse(bookingDetails);
        }
    }
}