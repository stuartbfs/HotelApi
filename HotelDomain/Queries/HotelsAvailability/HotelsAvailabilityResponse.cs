using HotelDomain.Model;

namespace HotelDomain.Queries.HotelsAvailability
{
    public class HotelsAvailabilityResponse : PageResponse
    {
        public HotelsAvailabilityResponse(int page, int pageSize, int totalCount)
            : base(page, pageSize, totalCount)
        {
        }

        public List<HotelRooms> Hotels { get; set; } = new List<HotelRooms>();
    }
}
