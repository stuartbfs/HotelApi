using FluentValidation;

namespace HotelDomain.Model
{
    public class BookingTimesValidator : AbstractValidator<IBookingTime>
    {
        public BookingTimesValidator()
        {
            RuleFor(x => x.CheckOut.Date).GreaterThan(x => x.CheckIn.Date);
        }
    }
}
