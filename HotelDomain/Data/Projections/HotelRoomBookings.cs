using System.Linq.Expressions;
using HotelDomain.Data.Entities;
using HotelDomain.Model;

namespace HotelDomain.Data.Projections
{
    public class HotelRoomBookings
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; }

        public Guid RoomId { get; set; }
        public string RoomName { get; set; }

        public string RoomType { get; set; }
        public int RoomCapacity { get; set; }

        public bool HasBooking { get; set; }

        public static Expression<Func<Room, HotelRoomBookings>> Projection(DateTime checkIn, DateTime checkOut)
        {
            var roomBooking = new RoomBooking { CheckIn = checkIn, Checkout = checkOut };
            var clashFunc = BookingTimes.ClashExpr<RoomBooking, RoomBooking>(roomBooking);

            return room => new HotelRoomBookings
            {
                HotelId = room.HotelId,
                HotelName = room.Hotel.Name,

                RoomId = room.RoomId,
                RoomName = room.Name,

                RoomType = room.RoomType.Name,
                RoomCapacity = room.RoomType.Capacity,

                HasBooking = room.RoomBookings.AsQueryable().Any(clashFunc)
            };
        }
    }
}
