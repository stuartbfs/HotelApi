using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Commands.BookRoom
{
    public class BookRoomRequest : BookRoomRequestBody, IRequest<BookRoomResponse>, IBookingTime
    {
        public BookRoomRequest(Guid hotelId, BookRoomRequestBody requestBody)
        {
            HotelId = hotelId;
            FirstName = requestBody.FirstName;
            LastName = requestBody.LastName;
            CheckIn = requestBody.CheckIn;
            CheckOut = requestBody.CheckOut;
            RoomType = requestBody.RoomType;
            PartySize = requestBody.PartySize;
        }

        public Guid HotelId { get; }
    }


    public class BookRoomRequestBody
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int PartySize { get; set; }

        public string RoomType { get; set; } = "";
    }
}