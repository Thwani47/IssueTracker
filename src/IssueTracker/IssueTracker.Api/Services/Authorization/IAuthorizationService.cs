using IssueTracker.DataAccess.Models.Authentication;

namespace IssueTracker.Api.Services.Authorization;

public interface IAuthorizationService
{
    Task<LoginResult> DoLogin(LoginRequest request);
    Task<RegisterResult> DoRegister(RegisterRequest request);
    Task<ResetPasswordResult> DoPasswordReset(PasswordResetRequest request);
}