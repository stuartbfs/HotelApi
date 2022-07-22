using HotelDomain.Model;

namespace HotelDomain.Queries.HotelRoomAvailability
{
    public class HotelRoomAvailabilityResponse
    {
        public HotelRoomAvailabilityResponse(Guid hotelId, string name, bool hasAvailability, List<HotelRoom> rooms)
        {
            HotelId = hotelId;
            Name = name;
            HasAvailability = hasAvailability;
            Rooms = rooms;
        }

        public Guid HotelId { get; }
        public string Name { get; }
        public bool HasAvailability { get; }
        public List<HotelRoom> Rooms { get; }
    }
}
