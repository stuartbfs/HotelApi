using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HotelDomain.Model;

namespace HotelDomain.Queries.FindBooking
{
    public class FindBookingRequestValidator : AbstractValidator<FindBookingRequest>
    {
        public FindBookingRequestValidator()
        {
            RuleFor(x => x.BookingRef).Custom(ValidateBookingRef);
        }

        private void ValidateBookingRef(string bookingRef, ValidationContext<FindBookingRequest> context)
        {
            var bookingNumber = BookingRefNumber.GetBookingNumber(bookingRef);

            if (bookingNumber <= 0)
            {
                context.AddFailure("Not a valid Booking Ref.");
            }
        }
    }
}
