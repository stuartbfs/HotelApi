namespace HotelDomain.Commands.BookRoom
{
    public class BookingHandler : ICommandHandler<BookRoomRequest, BookRoomResponse>
    {
        public async Task<BookRoomResponse> Handle(BookRoomRequest request)
        {
            throw new NotImplementedException();
        }
    }
}