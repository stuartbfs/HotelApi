using System.Data.Common;
using Azure.Core;
using Azure.Identity;
using Microsoft.Data.SqlClient;

namespace HotelApi.Infrastructure
{
    public class DbAccessTokenProvider : IDbAccessTokenProvider
    {
        private readonly ManagedIdentityCredential _credential = new ManagedIdentityCredential();

        public void ApplyAccessToken(DbConnection connection)
        {
            if (connection is SqlConnection sqlConnection)
            {
                var token = _credential.GetToken(CreateTokenRequestContext());
                sqlConnection.AccessToken = token.Token;
            }
        }

        public async Task ApplyAccessTokenAsync(DbConnection connection)
        {
            if (connection is SqlConnection sqlConnection)
            {
                var token = await _credential.GetTokenAsync(CreateTokenRequestContext());
                sqlConnection.AccessToken = token.Token;
            }
        }
        
        private TokenRequestContext CreateTokenRequestContext() => new TokenRequestContext(new[] { "https://database.windows.net/.default" });
    }
}
