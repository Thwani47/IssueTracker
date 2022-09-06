using IssueTracker.Api.Services;
using IssueTracker.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;
    public UsersController(IUserService userService, ILogger<UsersController> logger)
    {
        _logger = logger;
        _userService = userService;
    }
    
    [HttpGet("data/userId/{userId}")]
    public async Task<IActionResult> GetData(string userId)
    {
        try
        {
            var result = await _userService.DoGetUserData(userId);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { Message = "User not found" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error fetching user data: {e.Message}");
            return BadRequest(new { Message = "Error fetching user data" });
        }
    }
}