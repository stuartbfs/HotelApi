﻿using HotelDomain.Data.Entities;
using HotelDomain.Exceptions;
using HotelDomain.Model;
using Microsoft.EntityFrameworkCore;

namespace HotelDomain.Data.Seed
{
    public static class HotelsDbContextDataSeed
    {
        private static readonly Random _random = new Random((int)DateTime.Now.Ticks);

        public static async Task Initialize(HotelsDbContext context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();

            foreach (var hotelName in GetRandomizedHotelNames())
            {
                var hotel = new Hotel
                {
                    HotelName = hotelName,
                    Rooms = new List<Room>
                    {
                        new Room { RoomName = "Room 101", RoomTypeId = RoomTypes.Single.RoomTypeId },
                        new Room { RoomName = "Room 102", RoomTypeId = RoomTypes.Single.RoomTypeId },
                        new Room { RoomName = "Room 103", RoomTypeId = RoomTypes.Double.RoomTypeId },
                        new Room { RoomName = "Room 104", RoomTypeId = RoomTypes.Double.RoomTypeId },
                        new Room { RoomName = "Room 105", RoomTypeId = RoomTypes.Double.RoomTypeId },
                        new Room { RoomName = "Room 106", RoomTypeId = RoomTypes.Deluxe.RoomTypeId },
                    }
                };

                await context.Hotels.AddAsync(hotel);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedBookings(HotelsDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!await context.Hotels.AnyAsync())
            {
                throw new ValidationException("Hotel data not found. Try Reset first");
            }
        }

        private static IEnumerable<string> GetRandomizedHotelNames()
        {
            return GetHotelNames().OrderBy(x => _random.Next());
        }

        private static IEnumerable<string> GetHotelNames()
        {
            foreach (var area in GetAreas())
            {
                foreach (var brand in GetHotelBrands())
                {
                    yield return $"{area} {brand}";
                }
            }
        }

        private static IEnumerable<string> GetAreas()
        {
            yield return "Govanhill";
            yield return "Pollokshields";
            yield return "Partick";
            yield return "Hillhead";
            yield return "Shawlands";
            yield return "Langside";
            yield return "Ibrox";
            yield return "Easterhouse";
            yield return "Govan";
            yield return "Castlemilk";
            yield return "Bearsden";
            yield return "Newton Mearns";
            yield return "Gartnethill";
            yield return "Anderston";
            yield return "Gallowgate";
            yield return "Woodlands";
        }

        private static IEnumerable<string> GetHotelBrands()
        {
            yield return "Resort";
            yield return "Hotel";
            yield return "Inn";
            yield return "Motel";
            yield return "Hilton";
            yield return "Mariot";
            yield return "Guesthouse";
            yield return "B&B";
            yield return "Radisson";
            yield return "Premier Inn";
            yield return "Golf and Country Club";
        }
    }
}
