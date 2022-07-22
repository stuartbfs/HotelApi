using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HotelDomain.Data;
using HotelDomain.Data.Entities;
using HotelDomain.Data.Repository;
using HotelDomain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;

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
            

            //builder.Property(x => x.BookingNumber).ValueGeneratedOnAdd();

            //builder.HasIndex(x => x.BookingNumber).IsUnique();

            //builder.Property(x => x.BookingDate).ValueGeneratedOnAdd();

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

        [Fact]
        public async Task CreateBooking_Success()
        {
            //// Arrange
            //var generator = new BookingGenerator(
            //    "Boris", 
            //    "Johnson", 
            //    new DateTime(2010, 10, 05),
            //    new DateTime(2010, 10, 07), 
            //    2);

            //// Act
            //var result = await _bookingRepository.CreateBooking(
            //    generator,
            //    _hotelId
            //);

            //result.Should().NotBeNull();
        }

        //[Fact]
        //public async Task IsRoomBooked_True()
        //{
        //    // Act
        //    var result = await _hotelRepository.IsRoomBooked(_room4Id,
        //        new DateTime(2010, 10, 05),
        //        new DateTime(2010, 10, 10));

        //    // Assert
        //    result.Should().BeTrue();
        //}

        //[Fact]
        //public async Task AvailableRooms_All()
        //{
        //    // Act
        //    var result = await _hotelRepository.GetRoomAvailability(_hotelId,
        //        new DateTime(2010, 10, 05),
        //        new DateTime(2010, 10, 07));

        //    // Assert
        //    result.Should().HaveCount(6);
        //    result.Should().NotContain(x => x.HasBooking);
        //}

        //[Fact]
        //public async Task AvailableRooms_HasBooking()
        //{
        //    // Act
        //    var result = await _hotelRepository.GetRoomAvailability(_hotelId,
        //        new DateTime(2010, 10, 05),
        //        new DateTime(2010, 10, 10));

        //    // Assert
        //    result.Should().HaveCount(6);
        //    result.Should().ContainSingle(x => x.HasBooking && x.RoomId == _room4Id);
        //}
    }
}
