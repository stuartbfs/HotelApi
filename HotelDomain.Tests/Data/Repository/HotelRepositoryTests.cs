using FluentAssertions;
using HotelDomain.Data;
using HotelDomain.Data.Entities;
using HotelDomain.Data.Repository;
using HotelDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Tests.Data.Repository
{
    public class HotelRepositoryTests
    {
        private readonly DbContextOptions<HotelsDbContext> _contextOptions;

        private readonly HotelRepository _hotelRepository;

        private readonly Guid _hotelId;
        private readonly Guid _room4Id;

        public HotelRepositoryTests()
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

            _hotelRepository = new HotelRepository(context);
        }

        [Fact]
        public async Task IsRoomBooked_False()
        {
            // Act
            var result = await _hotelRepository.IsRoomBooked(_room4Id, 
                new DateTime(2010, 10, 05), 
                new DateTime(2010, 10, 07));

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task IsRoomBooked_True()
        {
            // Act
            var result = await _hotelRepository.IsRoomBooked(_room4Id,
                new DateTime(2010, 10, 05),
                new DateTime(2010, 10, 10));

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task AvailableRooms_All()
        {
            // Act
            var result = await _hotelRepository.GetRoomAvailability(_hotelId,
                new DateTime(2010, 10, 05),
                new DateTime(2010, 10, 07));

            // Assert
            result.Should().HaveCount(6);
            result.Should().NotContain(x => x.HasBooking);
        }

        [Fact]
        public async Task AvailableRooms_HasBooking()
        {
            // Act
            var result = await _hotelRepository.GetRoomAvailability(_hotelId,
                new DateTime(2010, 10, 05),
                new DateTime(2010, 10, 10));

            // Assert
            result.Should().HaveCount(6);
            result.Should().ContainSingle(x => x.HasBooking && x.RoomId == _room4Id);
        }
    }
}
