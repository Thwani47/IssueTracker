using IssueTracker.DataAccess.Models.Users;

namespace IssueTracker.Api.Services;

public interface IUserService
{
    Task<UserDataResult> DoGetUserData(string userId);
}