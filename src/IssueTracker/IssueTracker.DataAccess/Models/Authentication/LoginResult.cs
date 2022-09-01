namespace IssueTracker.DataAccess.Models.Authentication;

public class LoginResult : BaseResult
{
    public Dictionary<string, object> Data { get; set; }
}