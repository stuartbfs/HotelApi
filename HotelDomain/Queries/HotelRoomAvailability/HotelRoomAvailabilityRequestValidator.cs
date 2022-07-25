using FluentValidation;
using HotelDomain.Model;

namespace HotelDomain.Queries.HotelRoomAvailability
{
    public class HotelRoomAvailabilityRequestValidator : AbstractValidator<HotelRoomAvailabilityRequest>
    {
        public HotelRoomAvailabilityRequestValidator()
        {
            Include(new BookingTimesValidator());
        }
    }
}
