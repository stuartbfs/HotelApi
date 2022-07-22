using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HotelDomain.Model;

namespace HotelDomain.Tests.Model
{
    public class BookingTimesTests
    {
        public class BookingTime : IBookingTime
        {
            public DateTime CheckIn { get; set; }
            public DateTime Checkout { get; set; }
        }

        [Theory]
        [MemberData(nameof(IsValidTestCases))]
        public void IsValid_Tests(BookingTime bookingTime, bool isValid)
        {
            var result = BookingTimes.IsValid(bookingTime);

            result.Should().Be(isValid);
        }

        public static IEnumerable<object[]> IsValidTestCases()
        {
            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 06) }, true
            };
            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 05) }, false
            };
            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 04) }, false
            };
        }
        
        [Theory]
        [MemberData(nameof(ClashTestCases))]
        public void ClashExpr_Tests(BookingTime left, BookingTime right, bool hasClash)
        {
            // Arrange
            var expr = BookingTimes.ClashExpr<BookingTime, BookingTime>(right).Compile();

            // Act
            var result = expr.Invoke(left);

            // Assert
            result.Should().Be(hasClash);
        }

        [Theory]
        [MemberData(nameof(ClashTestCases))]
        public void ClashExpr_Inverse_Tests(BookingTime left, BookingTime right, bool hasClash)
        {
            // Arrange
            var expr = BookingTimes.ClashExpr<BookingTime, BookingTime>(left).Compile();

            // Act
            var result = expr.Invoke(right);

            // Assert
            result.Should().Be(hasClash);
        }
        
        public static IEnumerable<object[]> ClashTestCases()
        {
            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 01), Checkout = new DateTime(2010, 10, 05) },
                false
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 10), Checkout = new DateTime(2010, 10, 15) },
                false
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 06) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 09), Checkout = new DateTime(2010, 10, 10) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 04), Checkout = new DateTime(2010, 10, 11) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 06), Checkout = new DateTime(2010, 10, 09) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 08), Checkout = new DateTime(2010, 10, 12) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), Checkout = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 03), Checkout = new DateTime(2010, 10, 07) },
                true
            };
        }
    }
}
