using IssueTracker.Api.Options;
using IssueTracker.DataAccess;
using IssueTracker.DataAccess.Models.Authentication;
using Microsoft.Extensions.Options;

namespace IssueTracker.Api.Services;

public class AuthorizationService : IAuthorizationService
{
    private readonly JwtOptions _jwtOptions;
    private IDataAccess _dapperDataAccess;

    public AuthorizationService(IOptions<JwtOptions> jwtOptions, IDataAccess dapperDataAccess)
    {
        _jwtOptions = jwtOptions.Value;
        _dapperDataAccess = dapperDataAccess;
    }

    public Task<LoginResult> DoLogin(LoginRequest request)
    {
        // check is username exists
        
        // confirm password correct
        
        // generate token
        
        // return result
    }
}