using FluentValidation;
using HotelDomain.Model;

namespace HotelDomain.Commands.BookRoom
{
    public class BookRoomRequestValidator : AbstractValidator<BookRoomRequest>
    {
        public BookRoomRequestValidator()
        {
            Include(new BookingTimesValidator());

            RuleFor(x => x.HotelId).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.PartySize).Custom(ValidatePartySize);
        }

        private void ValidatePartySize(int partySize, ValidationContext<BookRoomRequest> context)
        {
            var roomType = context.InstanceToValidate.RoomType;
            switch (roomType)
            {
                case nameof(RoomTypes.Single):
                    if (partySize is <= 0 or > 1)
                    {
                        context.AddFailure("A single room can only accomodate 1 person");
                    }
                    break;
                case nameof(RoomTypes.Double):
                    if (partySize is <= 0 or > 2)
                    {
                        context.AddFailure("A double room can only accomodate a maximum of 2 persons");
                    }
                    break;
                case nameof(RoomTypes.Deluxe):
                    if (partySize is <= 0 or > 2)
                    {
                        context.AddFailure("A deluxe room can only accomodate a maximum of 2 persons");
                    }
                    break;
                default:
                    {
                        context.AddFailure(nameof(BookRoomRequest.RoomType), $"Unknown {roomType}");
                    }
                    break;
            }
        }
    }
}
