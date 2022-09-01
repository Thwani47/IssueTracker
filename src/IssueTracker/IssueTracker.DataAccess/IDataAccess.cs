using System.Data;
using IssueTracker.DataAccess.Models;

namespace IssueTracker.DataAccess;

public interface IDataAccess
{
    Task ExecuteAsync(Database database, string query, object parameters, int? timeout = null, CommandType commandType = CommandType.StoredProcedure);

    Task<IEnumerable<T>> QueryAsync<T>(Database database, string query, object parameters, int? timeout = null, CommandType commandType = CommandType.StoredProcedure);
}