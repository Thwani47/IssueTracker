using IssueTracker.DataAccess.Models;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace IssueTracker.DataAccess.Providers.ConnectionStringProviders;

public class AppSettingsConnectionStringProvider : IConnectionStringProvider
{
    private readonly IAppCache _appCache;
    private readonly IConfiguration _configuration;

    public AppSettingsConnectionStringProvider(IConfiguration configuration, IAppCache appCache)
    {
        _appCache = appCache;
        _configuration = configuration;
    }
    
    public Task<string> GetConnectionString(Database database)
    {
        var cacheOptions = new MemoryCacheEntryOptions
        {
            Priority = CacheItemPriority.NeverRemove
        };

        return _appCache.GetOrAddAsync(database.DatabaseName, _ => AddItemFactoryAsync(database.DatabaseName), cacheOptions);
    }

    private Task<string> AddItemFactoryAsync(string databaseName)
    {
        var connectionString = _configuration.GetConnectionString(databaseName);
        return Task.FromResult(connectionString);
    }
}