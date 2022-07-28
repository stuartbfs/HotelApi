using FluentValidation.Validators;
using HotelDomain.Data.Repository;
using HotelDomain.Exceptions;
using HotelDomain.Model;
using MediatR;

namespace HotelDomain.Queries.FindBooking
{
    public class FindBookingQueryHandler : IRequestHandler<FindBookingRequest, FindBookingResponse>
    {
        private readonly IBookingRepository _repository;

        public FindBookingQueryHandler(IBookingRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<FindBookingResponse> Handle(FindBookingRequest request, CancellationToken cancellationToken)
        {
            var bookingNumber = BookingRefNumber.GetBookingNumber(request.BookingRef);

            var bookingDetails = await _repository.GetBooking(bookingNumber);

            if (bookingDetails is null || !bookingDetails.Any())
            {
                throw new NotFoundException("Booking not found.");
            }

            return new FindBookingResponse(bookingDetails);
        }
    }
}
