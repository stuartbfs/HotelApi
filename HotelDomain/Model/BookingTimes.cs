using System.Linq.Expressions;
using HotelDomain.Exceptions;

namespace HotelDomain.Model
{
    public class BookingTimes
    {
        public static bool IsValid(IBookingTime bookingTime)
        {
            return bookingTime.CheckIn.Date < bookingTime.CheckOut.Date;
        }

        public static void ThrowIfInvalid(IBookingTime bookingTime)
        {
            if (IsValid(bookingTime)) return;

            throw new ValidationException("CheckIn must be before Checkout");
        }

        public static Expression<Func<TEntity, bool>> ClashExpr<TEntity, TParam>(TParam bookingParam)
            where TEntity : class, IBookingTime
            where TParam : IBookingTime
        {
            return entity =>
                (entity.CheckIn.Date <= bookingParam.CheckIn.Date && bookingParam.CheckOut.Date <= entity.CheckOut.Date) ||
                (bookingParam.CheckIn.Date <= entity.CheckIn.Date && entity.CheckOut.Date <= bookingParam.CheckOut.Date) ||
                (entity.CheckIn.Date >= bookingParam.CheckIn.Date && entity.CheckIn.Date < bookingParam.CheckOut.Date) ||
                (bookingParam.CheckIn.Date >= entity.CheckIn.Date && bookingParam.CheckIn.Date < entity.CheckOut.Date);
        }
    }
}
