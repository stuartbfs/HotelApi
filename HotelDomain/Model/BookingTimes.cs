using System.Linq.Expressions;

namespace HotelDomain.Model
{
    public class BookingTimes
    {
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
