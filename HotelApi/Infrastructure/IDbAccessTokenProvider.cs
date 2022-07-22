using System.Data.Common;

namespace HotelApi.Infrastructure
{
    public interface IDbAccessTokenProvider
    {
        void ApplyAccessToken(DbConnection connection);

        Task ApplyAccessTokenAsync(DbConnection connection);
    }
}
