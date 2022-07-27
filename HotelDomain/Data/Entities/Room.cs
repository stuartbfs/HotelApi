namespace HotelDomain.Data.Entities
{
    public class Room
    {
        public Guid RoomId { get; set; }

        public string RoomName { get; set; } = "";

        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;

        public Guid RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = null!;

        public ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();
    }
}
