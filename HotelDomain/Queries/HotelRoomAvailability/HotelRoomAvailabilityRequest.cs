using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Queries.HotelRoomAvailability
{
    public class HotelRoomAvailabilityRequest : IBookingTime, IRequest<HotelRoomAvailabilityResponse>
    {
        public HotelRoomAvailabilityRequest(Guid hotelId, DateTime checkIn, DateTime checkOut, int partySize)
        {
            HotelId = hotelId;
            CheckIn = checkIn;
            CheckOut = checkOut;
            PartySize = partySize;
        }

        public Guid HotelId { get; } 
        
        public DateTime CheckIn { get; }
        
        public DateTime CheckOut { get; }
        
        public int PartySize { get; }
    }
}
