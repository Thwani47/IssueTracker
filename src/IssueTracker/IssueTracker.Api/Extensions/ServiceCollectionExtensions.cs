using IssueTracker.Api.Options;
using IssueTracker.Api.Services.Authorization;
using IssueTracker.Api.Services.IssueService;
using IssueTracker.Api.Services.ProductService;
using IssueTracker.Api.Services.TeamService;
using IssueTracker.Api.Services.UserService;

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
        services.AddSingleton<IIssueService, IssueService>();
        return services;
    }
}