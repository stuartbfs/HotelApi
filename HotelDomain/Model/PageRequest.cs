using HotelDomain.Exceptions;

namespace HotelDomain.Model
{
    public class PageRequest
    {
        protected PageRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
        
        public int Page { get; }
        
        public int PageSize { get; }
    }
}