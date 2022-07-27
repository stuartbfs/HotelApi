using HotelDomain.Data.Repository;
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

            return new FindBookingResponse
            {
                Details = bookingDetails.ToArray()
            };
        }
    }
}
