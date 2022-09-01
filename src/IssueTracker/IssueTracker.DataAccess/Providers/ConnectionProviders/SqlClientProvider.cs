using System.Data;
using System.Data.SqlClient;

namespace IssueTracker.DataAccess.Providers.ConnectionProviders;

public class SqlClientProvider : IConnectionProvider
{
    public Task<IDbConnection> OpenAsync(string connectionString)
    {
        return OpenAsync(connectionString, new CancellationToken());
    }

    private async Task<IDbConnection> OpenAsync(string connectionString, CancellationToken cancellationToken)
    {
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}