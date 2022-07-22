using HotelDomain.Data.Entities;

namespace HotelDomain.Model
{
    public class RoomTypes
    {
        public static readonly RoomType Single = new RoomType
        {
            RoomTypeId = new Guid("910a4fb0-ff9d-4181-b938-77de6a2b2d3b"), Name = nameof(Single), Capacity = 1
        };

        public static readonly RoomType Double = new RoomType
        {
            RoomTypeId = new Guid("8dcbdaae-6f31-4fc9-96b5-fa363a92f68a"), Name = nameof(Double), Capacity = 2
        };

        public static readonly RoomType Deluxe = new RoomType
        {
            RoomTypeId = new Guid("e1cc15ec-2df4-45d6-8ee8-f7fcdc33680e"), Name = nameof(Deluxe), Capacity = 2
        };

        public static readonly RoomType[] All = {
            Single,
            Double,
            Deluxe
        };
    }
}
