namespace IssueTracker.DataAccess.Models.Authentication;

public class BaseResult
{
    public AuthRequestStatus Status { get; set; } 
    public string Message { get; set; }
}