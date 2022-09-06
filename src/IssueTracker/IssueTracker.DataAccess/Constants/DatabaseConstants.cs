namespace IssueTracker.DataAccess.Constants;

public static class DatabaseConstants
{
    public static readonly string LogUserInStoredProc = "dbo.pr_LogUserIn";
    public static readonly string InsertNewUserStoredProc = "dbo.pr_InsertNewUser";
    public static readonly string ResetUserPasswordStoredProc = "dbo.pr_ResetUserPassword";
    public static readonly string GetUserByUsernameStoredProc = "dbo.pr_GetUserByUserName";
    public static readonly string GetUserByIdStoredProc = "dbo.pr_GetUserById";
}