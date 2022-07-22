using HotelDomain.Queries.HotelRoomAvailability;
using HotelDomain.Queries.HotelsAvailability;
using Microsoft.Extensions.DependencyInjection;

namespace HotelDomain.Queries
{
    public static class Config
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddTransient<IQueryHandler<HotelsAvailabilityRequest, HotelsAvailabilityResponse>, HotelsAvailabilityQueryHandler>();
            services.AddTransient<IQueryHandler<HotelRoomAvailabilityRequest, HotelRoomAvailabilityResponse>, HotelRoomAvailabilityQueryHandler>();
        }
    }
}