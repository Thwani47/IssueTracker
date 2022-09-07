using IssueTracker.Api.Services.IssueService;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class IssuesController : ControllerBase
{
    private readonly IIssueService _authorizationService;
    private readonly ILogger<IssuesController> _logger;

    public IssuesController(IIssueService authorizationService, ILogger<IssuesController> logger)
    {
        _authorizationService = authorizationService;
        _logger = logger;
    }
}