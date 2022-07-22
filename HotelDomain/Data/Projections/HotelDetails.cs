using System.Linq.Expressions;
using HotelDomain.Data.Entities;

namespace HotelDomain.Data.Projections
{
    public class HotelDetails
    {
        public Guid HotelId { get; set; }
        public string Name { get; set; }

        public static readonly Expression<Func<Hotel, HotelDetails>> Projection = hotel => new HotelDetails
        {
            HotelId = hotel.HotelId,
            Name = hotel.HotelName
        };
    }
}