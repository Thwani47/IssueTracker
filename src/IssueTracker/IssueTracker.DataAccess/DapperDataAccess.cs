using System.Data;
using System.Data.SqlClient;
using Dapper;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Options;
using IssueTracker.DataAccess.Providers.ConnectionProviders;
using IssueTracker.DataAccess.Providers.ConnectionStringProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;

namespace IssueTracker.DataAccess;

public class DapperDataAccess : IDataAccess
{
    private IConnectionProvider _connectionProvider;
    private readonly ILogger<DapperDataAccess> _logger;
    private DatabaseRetryOptions _databaseRetryOptions;
    private IConnectionStringProvider _connectionStringProvider;

    public DapperDataAccess(IConnectionProvider connectionProvider, ILogger<DapperDataAccess> logger, IOptions<DatabaseRetryOptions> databaseRetryOptions, IConnectionStringProvider connectionStringProvider)
    {
        _connectionProvider = connectionProvider;
        _logger = logger;
        _databaseRetryOptions = databaseRetryOptions.Value;
        _connectionStringProvider = connectionStringProvider;
    }

    public async Task ExecuteAsync(Database database, string query, object parameters, int? timeout = null, CommandType commandType = CommandType.StoredProcedure)
    {
        await CreateRetryPolicy().ExecuteAsync(async () =>
        {
            var connectionString = await _connectionStringProvider.GetConnectionString(database);
            using var connection = await _connectionProvider.OpenAsync(connectionString);
            await connection.ExecuteAsync(query, parameters, commandTimeout: timeout, commandType: commandType);
        });
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(Database database, string query, object parameters, int? timeout = null, CommandType commandType = CommandType.StoredProcedure)
    {
        return await CreateRetryPolicy().ExecuteAsync(async () =>
        {
            var connectionString = await _connectionStringProvider.GetConnectionString(database);
            using var connection = await _connectionProvider.OpenAsync(connectionString);
            return await connection.QueryAsync<T>(query, parameters, commandTimeout: timeout, commandType: commandType);
        });
    }

    private IAsyncPolicy CreateRetryPolicy()
    {
        var baseRetryCount = _databaseRetryOptions.RetryCount;
        var baseRetryDelay = _databaseRetryOptions.BaseRetryDelayInMilliseconds;
        var retryPolicy = Policy
            .Handle<SqlException>()
            .WaitAndRetryAsync(baseRetryCount, retryCount => TimeSpan.FromMilliseconds(baseRetryDelay * retryCount),
                (exception, timeSpan, retryCount, context) =>
                {
                    _logger.LogWarning($"Database operation failed. Beginning retry attempt {retryCount}");
                });

        return retryPolicy;
    }
}