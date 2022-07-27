using FluentAssertions;
using FluentValidation.TestHelper;
using HotelDomain.Model;

namespace HotelDomain.Tests.Model
{
    public class BookingTimesValidatorTests
    {
        public class BookingTime : IBookingTime
        {
            public DateTime CheckIn { get; set; }
            public DateTime CheckOut { get; set; }
        }

        private readonly BookingTimesValidator _validator = new BookingTimesValidator();

        [Theory]
        [MemberData(nameof(IsValidTestCases))]
        public void IsValid_Tests(BookingTime bookingTime, bool isValid)
        {
            var result = _validator.TestValidate(bookingTime);

            result.IsValid.Should().Be(isValid);
        }

        public static IEnumerable<object[]> IsValidTestCases()
        {
            yield return new object[]
            {
                new BookingTime
                {
                    CheckIn = new DateTime(2010, 10, 05), 
                    CheckOut = new DateTime(2010, 10, 06)
                }, true
            };
            yield return new object[]
            {
                new BookingTime
                {
                    CheckIn = new DateTime(2010, 10, 05), 
                    CheckOut = new DateTime(2010, 10, 05)
                }, false
            };
            yield return new object[]
            {
                new BookingTime
                {
                    CheckIn = new DateTime(2010, 10, 05), 
                    CheckOut = new DateTime(2010, 10, 04)
                }, false
            };
        }
    }
}
