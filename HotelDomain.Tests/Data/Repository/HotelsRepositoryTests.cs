using FluentAssertions;
using HotelDomain.Data;
using HotelDomain.Data.Entities;
using HotelDomain.Data.Repository;
using HotelDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Tests.Data.Repository
{
    public class HotelsRepositoryTests
    {
        private readonly DbContextOptions<HotelsDbContext> _contextOptions;

        private readonly HotelsRepository _hotelRepository;

        private readonly Guid _hotelId;
        private readonly Guid _room4Id;

        public HotelsRepositoryTests()
        {
            _hotelId = Guid.NewGuid();
            _room4Id = Guid.NewGuid();

            _contextOptions = new DbContextOptionsBuilder<HotelsDbContext>()
                .UseInMemoryDatabase($"{nameof(HotelRepositoryTests)}_{Guid.NewGuid()}")
                .Options;

            var context = new HotelsDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Hotels.Add(new Hotel
            {
                HotelId = _hotelId,
                Name = "hotel paradiso",
                Rooms = new List<Room>
                {
                    new Room { Name = "Room 1", RoomTypeId = RoomTypes.Single.RoomTypeId },
                    new Room { Name = "Room 2", RoomTypeId = RoomTypes.Double.RoomTypeId },
                    new Room { Name = "Room 3", RoomTypeId = RoomTypes.Double.RoomTypeId },
                    new Room { RoomId = _room4Id, Name = "Room 4", RoomTypeId = RoomTypes.Single.RoomTypeId },
                    new Room { Name = "Room 5", RoomTypeId = RoomTypes.Deluxe.RoomTypeId },
                    new Room { Name = "Room 6", RoomTypeId = RoomTypes.Single.RoomTypeId }
                }
            });

            context.RoomBookings.Add(new RoomBooking
            {
                RoomId = _room4Id,
                CheckIn = new DateTime(2010, 10, 08),
                CheckOut = new DateTime(2010, 10, 12)
            });

            context.SaveChanges();

            _hotelRepository = new HotelsRepository(context);
        }

        [Fact]
        public async Task IsRoomBooked_False()
        {
            // Act
            var result = await _hotelRepository.GetRoomAvailability(
                new DateTime(2010, 10, 08),
                new DateTime(2010, 10, 12),
                2,
                1,
                10
            );

            // Assert
            result.Page.Should().Be(1);
            result.PageSize.Should().Be(10);
            result.TotalPages.Should().Be(1);
            result.TotalCount.Should().Be(1);
            result.Items.Should().HaveCount(5);
        }
    }
}