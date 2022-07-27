using HotelDomain.Data;
using HotelDomain.Data.Entities;
using HotelDomain.Data.Repository;
using HotelDomain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HotelDomain.Tests.Data.Repository
{
    public class BookingRepositoryTests
    {
        private readonly DbContextOptions<HotelsDbContext> _contextOptions;

        private readonly BookingRepository _bookingRepository;

        private readonly Guid _hotelId;
        private readonly Guid _room4Id;

        public BookingRepositoryTests()
        {
            _hotelId = Guid.NewGuid();
            _room4Id = Guid.NewGuid();

            _contextOptions = new DbContextOptionsBuilder<HotelsDbContext>()
                .UseInMemoryDatabase($"{nameof(BookingRepositoryTests)}_{Guid.NewGuid()}")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new HotelsDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            

            context.Hotels.Add(new Hotel
            {
                HotelId = _hotelId,
                HotelName = "hotel paradiso",
                Rooms = new List<Room>
                {
                    new Room { RoomName = "Room 1", RoomTypeId = RoomTypes.Single.RoomTypeId },
                    new Room { RoomName = "Room 2", RoomTypeId = RoomTypes.Double.RoomTypeId },
                    new Room { RoomName = "Room 3", RoomTypeId = RoomTypes.Double.RoomTypeId },
                    new Room { RoomId = _room4Id, RoomName = "Room 4", RoomTypeId = RoomTypes.Single.RoomTypeId },
                    new Room { RoomName = "Room 5", RoomTypeId = RoomTypes.Deluxe.RoomTypeId },
                    new Room { RoomName = "Room 6", RoomTypeId = RoomTypes.Single.RoomTypeId }
                }
            });

            context.RoomBookings.Add(new RoomBooking
            {
                RoomId = _room4Id,
                CheckIn = new DateTime(2010, 10, 08),
                CheckOut = new DateTime(2010, 10, 12)
            });

            context.SaveChanges();

            _bookingRepository = new BookingRepository(context);
        }
    }
}
