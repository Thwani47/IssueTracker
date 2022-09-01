using IssueTracker.DataAccess.Options;
using IssueTracker.DataAccess.Providers.ConnectionProviders;
using IssueTracker.DataAccess.Providers.ConnectionStringProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueTracker.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddLazyCache();
        services.Configure<DatabaseRetryOptions>(configuration.GetSection("DatabaseRetry"));
        services.AddSingleton<IConnectionProvider, SqlClientProvider>();
        services.AddSingleton<IConnectionStringProvider, AppSettingsConnectionStringProvider>();
        services.AddSingleton<IDataAccess, DapperDataAccess>();
        return services;
    }
}