using IssueTracker.Api.Options;
using IssueTracker.Api.Services;

namespace IssueTracker.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServiceCollectionExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        services.AddSingleton<IAuthorizationService, AuthorizationService>();
        services.AddSingleton<IUserService, UserService>();
        return services;
    }
}