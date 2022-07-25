using FluentValidation;
using HotelDomain.Model;

namespace HotelDomain.Queries.HotelsAvailability
{
    public class HotelsAvailabilityRequestValidator : AbstractValidator<HotelsAvailabilityRequest>
    {
        public HotelsAvailabilityRequestValidator()
        {
            Include(new PageRequestValidator());
            Include(new BookingTimesValidator());
        }
    }
}
