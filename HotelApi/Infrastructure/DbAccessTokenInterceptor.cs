using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace HotelApi.Infrastructure
{
    public class DbAccessTokenInterceptor : DbConnectionInterceptor
    {
        private readonly IDbAccessTokenProvider _accessTokenProvider;

        public DbAccessTokenInterceptor(IDbAccessTokenProvider accessTokenProvider)
        {
            _accessTokenProvider = accessTokenProvider ?? throw new ArgumentNullException(nameof(accessTokenProvider));
        }

        public override InterceptionResult ConnectionOpening(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
        {
            var interceptionResult = base.ConnectionOpening(connection, eventData, result);
            _accessTokenProvider.ApplyAccessToken(connection);
            return interceptionResult;
        }

        public override async ValueTask<InterceptionResult> ConnectionOpeningAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
        {
            var interceptionResult = await base.ConnectionOpeningAsync(connection, eventData, result, cancellationToken);
            await _accessTokenProvider.ApplyAccessTokenAsync(connection);
            return interceptionResult;
        }
    }
}
