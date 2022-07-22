using HotelDomain.Exceptions;
using HotelDomain.Model;

namespace HotelDomain.Queries.FindHotel
{
    public class FindHotelRequest : PageRequest
    {
        public FindHotelRequest(string searchName, int page, int pageSize)
            : base(page, pageSize)
        {
            SearchName = searchName;
        }
        
        public string SearchName { get; }
        
        public override void ThrowIfInvalid()
        {
            if (!string.IsNullOrWhiteSpace(SearchName)) return;
            
            throw new ValidationException("Name required");
        }
    }
}