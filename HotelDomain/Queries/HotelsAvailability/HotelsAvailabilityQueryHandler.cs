using HotelDomain.Data.Repository;
using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Queries.HotelsAvailability
{
    public class HotelsAvailabilityQueryHandler : IRequestHandler<HotelsAvailabilityRequest, HotelsAvailabilityResponse>
    {
        private readonly IHotelsRepository _hotelsRepository;
        
        public HotelsAvailabilityQueryHandler(IHotelsRepository hotelsRepository)
        {
            _hotelsRepository = hotelsRepository ?? throw new ArgumentNullException(nameof(hotelsRepository));
        }
        
        public async Task<HotelsAvailabilityResponse> Handle(HotelsAvailabilityRequest request, CancellationToken cancellationToken)
        {
            var results = await _hotelsRepository.GetRoomAvailability(
                request.CheckIn, 
                request.CheckOut, 
                request.PartySize, 
                request.Page, 
                request.PageSize);

            return new HotelsAvailabilityResponse(request.Page, request.PageSize, results.TotalCount)
            {
                Hotels = results.Items
                                .GroupBy(x => new { x.HotelId, x.HotelName })
                                .Select(x => new HotelRooms
                                {
                                    HotelId = x.Key.HotelId,
                                    Name = x.Key.HotelName,
                                    Rooms = x
                                        .Select(r => new HotelRoom(r))
                                        .ToList()
                                })
                                .ToList()
            };
        }
    }
}
