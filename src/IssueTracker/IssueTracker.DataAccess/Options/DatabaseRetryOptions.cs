namespace IssueTracker.DataAccess.Options;

public class DatabaseRetryOptions
{
    public int  RetryCount { get; set; }
    public int BaseRetryDelayInMilliseconds { get; set; }
}