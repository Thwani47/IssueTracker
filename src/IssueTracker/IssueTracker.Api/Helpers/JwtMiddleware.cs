using IssueTracker.Api.Options;
using IssueTracker.Api.Services;
using Microsoft.Extensions.Options;

namespace IssueTracker.Api.Helpers;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JwtOptions _jwtOptions;

    public JwtMiddleware(RequestDelegate next, IOptions<JwtOptions> jwtOptions)
    {
        _next = next;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            AttachUserToContext(context, userService, token);
        }

        await _next(context);
    }

    private void AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var jwtToken = JwtHelper.ValidateToken(token, _jwtOptions.Secret);
            var userId = jwtToken.Claims.First(x => x.Type == "Id").Value;
            context.Items["User"] = userService.DoGetUserData(userId);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error attaching user to context: {e.Message}");
        }
    }
}