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
        
        public virtual void ThrowIfInvalid()
        {
            if (Page <= 0) throw new ValidationException("Page must be greater than 0");

            if (PageSize <= 0) throw new ValidationException("PageSize must be greater than 0");
        }
    }
}