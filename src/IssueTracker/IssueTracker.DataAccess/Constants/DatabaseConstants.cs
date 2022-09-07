namespace IssueTracker.DataAccess.Constants;

public static class DatabaseConstants
{
    public static readonly string LogUserInStoredProc = "dbo.pr_LogUserIn";
    public static readonly string InsertNewUserStoredProc = "dbo.pr_InsertNewUser";
    public static readonly string ResetUserPasswordStoredProc = "dbo.pr_ResetUserPassword";
    public static readonly string GetUserByUsernameStoredProc = "dbo.pr_GetUserByUserName";
    public static readonly string GetAllUsersStoredProc = "dbo.pr_GetAllUsers";
    public static readonly string GetUserByIdStoredProc = "dbo.pr_GetUserById";
    public static readonly string GetAllTeamsStoredProc = "dbo.pr_GetAllTeams";
    public static readonly string GetTeamByIdStoredProc = "dbo.pr_GetTeamById";
    public static readonly string AddNewTeamStoredProc = "dbo.pr_InsertNewTeam";
    public static readonly string GetAllProductsStoredProc = "dbo.pr_GetAllProducts";
    public static readonly string GetProductByIdStoredProc = "dbo.pr_GetProductById";
    public static readonly string AddNewProductStoredProc = "dbo.pr_InsertNewProduct";
}