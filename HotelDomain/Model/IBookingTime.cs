namespace HotelDomain.Model
{
    public interface IBookingTime
    {
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
    }
}
