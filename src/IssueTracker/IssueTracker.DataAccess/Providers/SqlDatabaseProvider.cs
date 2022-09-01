using IssueTracker.DataAccess.Models;

namespace IssueTracker.DataAccess.Providers;

public static class SqlDatabaseProvider
{
    public static readonly IssueTrackerDatabase IssueTrackerDatabase = new IssueTrackerDatabase();
}

public class IssueTrackerDatabase : Database
{
    public IssueTrackerDatabase() : base("IssueTrackerDatabase")
    {
    }
}