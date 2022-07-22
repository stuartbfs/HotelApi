using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelDomain.Model
{
    public class BookingTimes
    {
        public static bool IsValid(IBookingTime bookingTime)
        {
            return bookingTime.CheckIn.Date < bookingTime.Checkout.Date;
        }

        public static Expression<Func<TEntity, bool>> ClashExpr<TEntity, TParam>(TParam bookingParam)
            where TEntity : class, IBookingTime
            where TParam : IBookingTime
        {
            return entity => (entity.CheckIn.Date <= bookingParam.CheckIn.Date && bookingParam.Checkout.Date <= entity.Checkout.Date) ||
                             (bookingParam.CheckIn.Date <= entity.CheckIn.Date && entity.Checkout.Date <= bookingParam.Checkout.Date);
        }
    }
}
