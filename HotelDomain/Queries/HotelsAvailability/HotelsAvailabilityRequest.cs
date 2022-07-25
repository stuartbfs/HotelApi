using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Queries.HotelsAvailability
{
    public class HotelsAvailabilityRequest : PageRequest, IRequest<HotelsAvailabilityResponse>, IBookingTime
    {
        public HotelsAvailabilityRequest(DateTime checkIn, DateTime checkOut, int partySize, int page, int pageSize)
            : base(page, pageSize)
        {
            CheckIn = checkIn;
            CheckOut = checkOut;
            PartySize = partySize;
        }

        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
        public int PartySize { get; }
    }
}
