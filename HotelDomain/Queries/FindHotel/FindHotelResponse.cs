using HotelDomain.Data.Projections;
using HotelDomain.Model;

namespace HotelDomain.Queries.FindHotel
{
    public class FindHotelResponse : PageResponse
    {
        public FindHotelResponse(int page, int pageSize, int totalCount)
            : base(page, pageSize, totalCount)
        {
        }
        
        public List<HotelDetails> Hotels { get; set; }
    }
}