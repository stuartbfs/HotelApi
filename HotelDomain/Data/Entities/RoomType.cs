namespace HotelDomain.Data.Entities
{
    public class RoomType
    {
        public Guid RoomTypeId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
