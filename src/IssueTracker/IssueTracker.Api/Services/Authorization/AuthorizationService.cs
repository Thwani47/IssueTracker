using System.Data;
using Dapper;
using IssueTracker.Api.Helpers;
using IssueTracker.Api.Options;
using IssueTracker.DataAccess;
using IssueTracker.DataAccess.Constants;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Authentication;
using IssueTracker.DataAccess.Models.Users;
using IssueTracker.DataAccess.Providers;
using Microsoft.Extensions.Options;

namespace IssueTracker.Api.Services.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly IDataAccess _dapperDataAccess;
    private readonly JwtOptions _jwtOptions;

    public AuthorizationService(IOptions<JwtOptions> jwtOptions, IDataAccess dapperDataAccess)
    {
        _jwtOptions = jwtOptions.Value;
        _dapperDataAccess = dapperDataAccess;
    }

    public async Task<LoginResult> DoLogin(LoginRequest request)
    {
        // check is username exists
        var (userExists, _) = await CheckUserExists(request.Username);
        if (!userExists)
        {
            return new LoginResult
            {
                Status = AuthRequestStatus.Failure,
                Message = "User not found"
            };
        }
        
        
        // Login user
        var parameters = new DynamicParameters();
        parameters.Add("@Username", request.Username);
        parameters.Add("@Password", request.Password);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size:100, direction: ParameterDirection.Output);
        parameters.Add("@UserId", dbType: DbType.Guid, size: 64, direction:ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.LogUserInStoredProc, parameters);
        
        var response = parameters.Get<string>("ResponseMessage");

        if (!response.Equals("Login Successful"))
            return new LoginResult
            {
                Message = $"Failed to log user in. {response}",
                Status = AuthRequestStatus.Failure
            };

        var userId = parameters.Get<Guid>("UserId");
        var token = JwtHelper.GenerateJwtToken(userId, _jwtOptions.Secret, _jwtOptions.Issuer, _jwtOptions.Audience);

        return new LoginResult
        {
            Message = "Login Successful",
            Status = AuthRequestStatus.Success,
            Data = new Dictionary<string, object>
            {
                {"token", token},
                {"UserId", userId}
            }
        };

    }

    public async Task<RegisterResult> DoRegister(RegisterRequest request)
    {
        // check if username is already taken
        var (userExists, _) = await CheckUserExists(request.Username);
        if (userExists)
        {
            return new RegisterResult
            {
                Message = "Failed to register user. Username already taken.",
                Status = AuthRequestStatus.Failure
            };
        }
        
        // check if password equals password confirm
        if (!request.Password.Equals(request.ConfirmPassword))
        {
            return new RegisterResult
            {
                Message = "Failed to register user. Password mismatch.",
                Status = AuthRequestStatus.Failure
            };
        }
        
        // register user
        var parameters = new DynamicParameters();
        parameters.Add("@FirstName", request.FirstName);
        parameters.Add("@LastName", request.LastName);
        parameters.Add("@Email", request.Email);
        parameters.Add("@UserType", (int)request.UserType);
        parameters.Add("@Username", request.Username);
        parameters.Add("@Password", request.Password);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size:100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.InsertNewUserStoredProc, parameters);

        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("User Added Successfully"))
        {
            return new RegisterResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new RegisterResult
        {
            Message = $"Failed to register user. {response}",
            Status = AuthRequestStatus.Failure
        };
    }

    public async Task<ResetPasswordResult> DoPasswordReset(PasswordResetRequest request)
    {
        // Check if username exists
        var (userExists, user) = await CheckUserExists(request.Username);
        if (!userExists)
        {
            return new ResetPasswordResult
            {
                Status = AuthRequestStatus.Failure,
                Message = "User not found"
            };
        }
        
        // Check if password matches
        if (!request.Password.Equals(request.ConfirmPassword))
        {
            return new ResetPasswordResult
            {
                Message = "Failed to register user. Password mismatch.",
                Status = AuthRequestStatus.Failure
            };
        }
        
        // Update password
        var parameters = new DynamicParameters();
        parameters.Add("@UserId", user.UserId.ToString());
        parameters.Add("@Password", request.Password);
        parameters.Add("@ResponseMessage", dbType: DbType.String, size:100, direction: ParameterDirection.Output);
        await _dapperDataAccess.ExecuteAsync(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.ResetUserPasswordStoredProc, parameters);
     
        var response = parameters.Get<string>("ResponseMessage");

        if (response.Equals("Password reset successfully"))
        {
            return new ResetPasswordResult
            {
                Status = AuthRequestStatus.Success,
                Message = response
            };
        }

        return new ResetPasswordResult
        {
            Message = $"Failed to reset user password. {response}",
            Status = AuthRequestStatus.Failure
        };
    }

    private async Task<(bool, User?)> CheckUserExists(string username)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@Username", username);
        var users = await _dapperDataAccess.QueryAsync<User>(SqlDatabaseProvider.IssueTrackerDatabase,
            DatabaseConstants.GetUserByUsernameStoredProc, parameters);

        var enumerable = users.ToList();
        return (enumerable.Any(), enumerable.FirstOrDefault());
    }
}