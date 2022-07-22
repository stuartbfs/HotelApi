namespace HotelDomain.Model
{
    public class HotelRooms
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public List<HotelRoom> Rooms { get; set; }
    }
}
