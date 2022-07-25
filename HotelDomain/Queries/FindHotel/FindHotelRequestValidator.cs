using FluentValidation;
using HotelDomain.Model;

namespace HotelDomain.Queries.FindHotel
{
    public class FindHotelRequestValidator : AbstractValidator<FindHotelRequest>
    {
        public FindHotelRequestValidator()
        {
            Include(new PageRequestValidator());
            RuleFor(x => x.SearchName).NotEmpty();
        }
    }
}
