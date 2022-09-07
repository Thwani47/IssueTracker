using IssueTracker.Api.Options;
using IssueTracker.Api.Services.Authorization;
using IssueTracker.Api.Services.Product;
using IssueTracker.Api.Services.Team;
using IssueTracker.Api.Services.User;

namespace IssueTracker.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServiceCollectionExtensions(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtOptions"));
        services.AddSingleton<IAuthorizationService, AuthorizationService>();
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<ITeamService, TeamService>();
        services.AddSingleton<IProductService, ProductService>();
        return services;
    }
}