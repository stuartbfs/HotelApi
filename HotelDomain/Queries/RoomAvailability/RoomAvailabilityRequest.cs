using HotelDomain.Model;

namespace HotelDomain.Queries.RoomAvailability
{
    public class RoomAvailabilityRequest : IBookingTime
    {
        public RoomAvailabilityRequest(DateTime checkIn, DateTime checkOut, int partySize, int page, int pageSize)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            PartySize = partySize;
            Page = page;
            PageSize = pageSize;
        }

        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public int PartySize { get; }
        public int Page { get; }
        public int PageSize { get; }
    }
}
