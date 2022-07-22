namespace HotelDomain.Model
{
    public abstract class PageResponse
    {
        protected PageResponse(int page, int pageSize, int totalCount)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public int Page { get; }
        public int PageSize { get; }
        public int TotalCount { get; }
        public int TotalPages => (int)Math.Round(Math.Ceiling(TotalCount/(decimal)PageSize));
    }
    
    public class PageResponse<TItemType> : PageResponse
    {
        public PageResponse(int page, int pageSize, int totalCount)
            : base(page, pageSize, totalCount)
        {
        }

        public List<TItemType> Items { get; set; } = new List<TItemType>();
    }
}
