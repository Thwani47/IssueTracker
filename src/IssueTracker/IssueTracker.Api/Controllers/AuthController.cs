using IssueTracker.Api.Services;
using IssueTracker.DataAccess.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthorizationService _authorizationService;
    private readonly ILogger<AuthController> _logger;
    public AuthController(IAuthorizationService authorizationService, ILogger<AuthController> logger)
    {
        _logger = logger;
        _authorizationService = authorizationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });

        try
        {
            var result = await _authorizationService.DoLogin(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return BadRequest(new { Message = "Invalid username or password" });
            }

            return Ok(new { Message = result.Message, Data = result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning("Error logging user in", e);
            return BadRequest(new { Message = "Error logging user in" });
        }
    }
}