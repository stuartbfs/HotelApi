using HotelDomain.Exceptions;
using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Queries.FindHotel
{
    public class FindHotelRequest : PageRequest, IRequest<FindHotelResponse>
    {
        public FindHotelRequest(string searchName, int page, int pageSize)
            : base(page, pageSize)
        {
            SearchName = searchName;
        }
        
        public string SearchName { get; }
    }
}