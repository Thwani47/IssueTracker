using Dapper;
using IssueTracker.DataAccess;
using IssueTracker.DataAccess.Constants;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Users;
using IssueTracker.DataAccess.Providers;

namespace IssueTracker.Api.Services.UserService;

public class UserService : IUserService
{
    private readonly IDataAccess _dapperDataAccess;

    public UserService(IDataAccess dapperDataAccess)
    {
        _dapperDataAccess = dapperDataAccess;
    }

    public async Task<UserDataResult> DoGetUserData(string userId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);
        var users = await _dapperDataAccess.QueryAsync<User>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetUserByIdStoredProc, parameters);

        var enumerable = users as User[] ?? users.ToArray();
        if (enumerable.Any())
        {
            return new UserDataResult
            {
                Message = "User found",
                Status = AuthRequestStatus.Success,
                Data = new Dictionary<string, object>
                {
                    { "user", enumerable.First() }
                }
            };
        }

        return new UserDataResult
        {
            Status = AuthRequestStatus.Failure,
            Message = "User not found"
        };
    }

    public async Task<UserDataResult> DoGetAllUsers(int userType)
    {
        var user = (UserType)userType;

        var storedProc = DatabaseConstants.GetAllUsersStoredProc;
        if (user is UserType.TeamLead or UserType.Developer)
        {
            storedProc = DatabaseConstants.GetAllDevelopersStoredProc;
        }
        var users = await _dapperDataAccess.QueryAsync<User>(SqlDatabaseProvider.IssueTrackerDatabase,
            storedProc);

        var enumerable = users.ToList();
        if (enumerable.Any())
        {
            return new UserDataResult()
            {
                Status = AuthRequestStatus.Success,
                Message = "Users found",
                Data = new Dictionary<string, object>
                {
                    {"users", enumerable}
                }
            };
        }

        return new UserDataResult
        {
            Status = AuthRequestStatus.Failure,
            Message = "No users found"
        };
    }
}