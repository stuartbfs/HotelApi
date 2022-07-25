using HotelDomain.Data.Repository;
using HotelDomain.Exceptions;
using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Queries.HotelRoomAvailability
{
    public class HotelRoomAvailabilityQueryHandler : IRequestHandler<HotelRoomAvailabilityRequest, HotelRoomAvailabilityResponse>
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelRoomAvailabilityQueryHandler(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }

        public async Task<HotelRoomAvailabilityResponse> Handle(HotelRoomAvailabilityRequest request, CancellationToken cancellationToken)
        {
            var results = await _hotelRepository.GetRoomAvailability(request.HotelId, request.CheckIn, request.CheckOut);
            if (results is null || results.Count == 0)
            {
                throw new BadRequestException("Unknown hotel");
            }

            var availableRooms = results.Where(x => !x.HasBooking).ToList();
            var capacity = availableRooms.Sum(x => x.RoomCapacity);
            var rooms = availableRooms.Select(x => new HotelRoom(x)).ToList();

            return new HotelRoomAvailabilityResponse(
                request.HotelId,
                results[0].HotelName,
                capacity <= request.PartySize,
                rooms);
        }
    }
}