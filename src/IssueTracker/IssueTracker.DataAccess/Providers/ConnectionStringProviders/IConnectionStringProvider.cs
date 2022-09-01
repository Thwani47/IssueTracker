using IssueTracker.DataAccess.Models;

namespace IssueTracker.DataAccess.Providers.ConnectionStringProviders;

public interface IConnectionStringProvider
{
    Task<string> GetConnectionString(Database database);
}