namespace HotelDomain.Data.Entities
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        
        public int BookingNumber { get; set; }

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        
        public DateTime BookingDate { get; set; }

        public ICollection<RoomBooking> Rooms { get; set; } = new List<RoomBooking>();
    }
}