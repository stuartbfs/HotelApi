namespace HotelDomain.Data.Entities
{
    public class Hotel
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; } = "";

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
