using HotelDomain.Data.Entities;
using HotelDomain.Data.Projections;
using HotelDomain.Exceptions;

namespace HotelDomain.Model
{
    public class BookingGenerator
    {
        private readonly string _firstName;
        private readonly string _lastName;

        private readonly string[] _roomTypes;

        public BookingGenerator(string firstName, string lastName, DateTime checkIn, DateTime checkOut, string[] roomTypes)
        {
            _firstName = firstName;
            _lastName = lastName;
            CheckIn = checkIn;
            CheckOut = checkOut;
            _roomTypes = roomTypes;
        }

        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }

        public Booking GenerateBooking(List<HotelRoomAvailability> availability)
        {
            //if (!availability.Any())
            //{
            //    throw new BadRequestException("Not enough rooms available");
            //}

            //foreach (var roomType in _roomTypes)
            //{
            //    if (!availability.Any(a => a.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase)))
            //    {
            //        throw new BadRequestException("Room type not v")
            //    }
            //}

            //var booking = new Booking
            //{
            //    FirstName = _firstName,
            //    LastName = _lastName,
            //    Rooms = new List<RoomBooking>()
            //};

            //var partyToBook = _partySize;
            //var rooms = new Queue<HotelRoomAvailability>(availability);
            //do
            //{
            //    var roomToBook = rooms.Dequeue();
            //    booking.Rooms.Add(new RoomBooking
            //    {
            //        RoomId = roomToBook.RoomId,
            //        CheckIn = CheckIn,
            //        CheckOut = CheckOut
            //    });
            //    partyToBook -= roomToBook.RoomCapacity;
            //} while (partyToBook > 0);

            return null;
        }
    }
}
