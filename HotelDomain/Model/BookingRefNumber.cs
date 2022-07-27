namespace HotelDomain.Model
{
    public class BookingRefNumber
    {
        public const string BookingRefNumberFormat = "D8";

        public static int GetBookingNumber(string bookingRefNumber)
        {
            if (!int.TryParse(bookingRefNumber, out var bookingNumber))
            {
                return -1;
            }

            return bookingNumber;
        }
    }
}
