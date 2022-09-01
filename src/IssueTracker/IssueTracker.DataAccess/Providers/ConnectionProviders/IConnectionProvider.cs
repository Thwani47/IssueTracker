using System.Data;

namespace IssueTracker.DataAccess.Providers.ConnectionProviders;

public interface IConnectionProvider
{
    Task<IDbConnection> OpenAsync(string connectionString);
}