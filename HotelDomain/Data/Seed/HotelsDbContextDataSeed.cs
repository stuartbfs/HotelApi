using HotelDomain.Data.Entities;
using HotelDomain.Model;

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
                    Rooms = new List<Room>(6)
                };

                for (var i = 1; i <= 6; i++)
                {
                    var room = new Room
                    {
                        RoomName = $"Room 10{i}",
                        RoomTypeId = GetRoomType()
                    };
                    hotel.Rooms.Add(room);
                }

                await context.Hotels.AddAsync(hotel);
            }

            await context.SaveChangesAsync();
        }

        private static Guid GetRoomType()
        {
            return RoomTypes.All[_random.Next(0, 3)].RoomTypeId;
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
