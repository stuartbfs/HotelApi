using HotelDomain.Data.Repository;

namespace HotelDomain.Queries.FindHotel
{
    public class FindHotelQueryHandler : IQueryHandler<FindHotelRequest, FindHotelResponse>
    {
        private readonly IHotelsRepository _hotelsRepository;
        
        public FindHotelQueryHandler(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository ?? throw new ArgumentNullException(nameof(hotelsRepository));
        }
        
        public async Task<FindHotelResponse> Handle(FindHotelRequest request)
        {
            request.ThrowIfInvalid();

            var results = await _hotelsRepository.FindHotels(request.SearchName, request.Page, request.PageSize);
            
            return new FindHotelResponse(request.Page, request.PageSize, results.TotalCount)
            {
                Hotels = results.Items
            };
        }
    }
}