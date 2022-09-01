using IssueTracker.DataAccess.Models.Authentication;

namespace IssueTracker.Api.Services;

public interface IAuthorizationService
{
    Task<LoginResult> DoLogin(LoginRequest request);
}