using HotelDomain.Data.Repository;
using MediatR;

namespace HotelDomain.Queries.FindHotel
{
    public class FindHotelQueryHandler : IRequestHandler<FindHotelRequest, FindHotelResponse>
    {
        private readonly IHotelsRepository _hotelsRepository;
        
        public FindHotelQueryHandler(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository ?? throw new ArgumentNullException(nameof(hotelsRepository));
        }

        public async Task<FindHotelResponse> Handle(FindHotelRequest request, CancellationToken cancellationToken)
        {
            var results = await _hotelsRepository.FindHotels(request.SearchName, request.Page, request.PageSize);

            return new FindHotelResponse(request.Page, request.PageSize, results.TotalCount)
            {
                Hotels = results.Items
            };
        }
    }
}