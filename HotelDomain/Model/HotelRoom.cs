using HotelDomain.Data.Projections;

namespace HotelDomain.Model
{
    public class HotelRoom
    {
        public HotelRoom(HotelRoomAvailability availability)
        {
            RoomName = availability.RoomName;
            RoomType = availability.RoomType;
        }

        public string RoomName { get; set; }
        public string RoomType { get; set; }
    }
}
