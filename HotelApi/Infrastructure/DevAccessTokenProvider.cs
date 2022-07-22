using System.Data.Common;

namespace HotelApi.Infrastructure
{
    public class DevAccessTokenProvider : IDbAccessTokenProvider
    {
        public void ApplyAccessToken(DbConnection connection)
        {
        }

        public Task ApplyAccessTokenAsync(DbConnection connection)
        {
            return Task.FromResult(0);
        }
    }
}
