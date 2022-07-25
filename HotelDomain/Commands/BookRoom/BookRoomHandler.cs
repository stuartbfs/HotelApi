using HotelDomain.Data.Repository;
using MediatR;

namespace HotelDomain.Commands.BookRoom
{
    public class BookingHandler : IRequestHandler<BookRoomRequest, BookRoomResponse>
    {
        public Task<BookRoomResponse> Handle(BookRoomRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}