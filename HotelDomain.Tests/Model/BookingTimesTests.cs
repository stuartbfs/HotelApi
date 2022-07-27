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
            public DateTime CheckOut { get; set; }
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
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 01), CheckOut = new DateTime(2010, 10, 05) },
                false
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 10), CheckOut = new DateTime(2010, 10, 15) },
                false
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 06) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 09), CheckOut = new DateTime(2010, 10, 10) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 04), CheckOut = new DateTime(2010, 10, 11) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 06), CheckOut = new DateTime(2010, 10, 09) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 08), CheckOut = new DateTime(2010, 10, 12) },
                true
            };

            yield return new object[]
            {
                new BookingTime { CheckIn = new DateTime(2010, 10, 05), CheckOut = new DateTime(2010, 10, 10) },
                new BookingTime { CheckIn = new DateTime(2010, 10, 03), CheckOut = new DateTime(2010, 10, 07) },
                true
            };
        }
    }
}
