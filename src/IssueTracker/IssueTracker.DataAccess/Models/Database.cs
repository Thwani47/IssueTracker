namespace IssueTracker.DataAccess.Models;

public class Database
{
    public string DatabaseName { get; set; }

    public Database(string databaseName)
    {
        DatabaseName = databaseName;
    }
}