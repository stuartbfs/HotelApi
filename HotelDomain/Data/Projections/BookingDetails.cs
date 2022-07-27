using System.Linq.Expressions;
using HotelDomain.Data.Entities;
using HotelDomain.Model;

namespace HotelDomain.Data.Projections
{
    public class BookingDetails
    {
        public string BookingNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int PartySize { get; set; }

        public string RoomType { get; set; } = string.Empty;

        public static Expression<Func<RoomBooking, BookingDetails>> Projection = room => new BookingDetails
        {
            BookingNumber = room.Booking.BookingNumber.ToString(BookingRefNumber.BookingRefNumberFormat),
            BookingDate = room.Booking.BookingDate,
            FirstName = room.Booking.FirstName,
            LastName = room.Booking.LastName,
            RoomName = room.Room.RoomName,
            HotelName = room.Room.Hotel.HotelName,
            CheckIn = room.CheckIn,
            CheckOut = room.CheckOut,
            PartySize = room.PartySize,
            RoomType = room.Room.RoomType.Name
        };
    }
}
