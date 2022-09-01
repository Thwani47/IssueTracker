using IssueTracker.DataAccess.Models;

namespace IssueTracker.DataAccess.Providers;

public class SqlDatabaseProvider
{
    public class IssueTrackerDatabase : Database
    {
        public IssueTrackerDatabase() : base("IssueTrackerDatabase")
        {
        }
    }
}