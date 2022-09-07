using IssueTracker.Api.Services;
using IssueTracker.DataAccess.Models;
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

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error logging user in: {e.Message}");
            return BadRequest(new { Message = "Error logging user in" });
        }
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });

        try
        {
            var result = await _authorizationService.DoRegister(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return BadRequest(new { Message = $"Error registering new user: {result.Message}" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error registering new user {e.Message}");
            return BadRequest(new { Message = "Error registering user" });
        }
    }
    
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] PasswordResetRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });

        try
        {
            var result = await _authorizationService.DoPasswordReset(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return BadRequest(new { result.Message });
            }

            return Ok(new { result.Message });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error resetting user password: {e.Message}");
            return BadRequest(new { Message = "Error resetting user password" });
        }
    }
}