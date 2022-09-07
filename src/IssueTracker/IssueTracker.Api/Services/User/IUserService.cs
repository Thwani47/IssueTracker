using IssueTracker.DataAccess.Models.Users;

namespace IssueTracker.Api.Services.User;

public interface IUserService
{
    Task<UserDataResult> DoGetUserData(string userId);
    Task<UserDataResult> DoGetAllUsers();
}