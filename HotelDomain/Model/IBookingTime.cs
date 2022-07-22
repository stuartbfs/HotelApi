namespace HotelDomain.Model
{
    public interface IBookingTime
    {
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }
    }
}
