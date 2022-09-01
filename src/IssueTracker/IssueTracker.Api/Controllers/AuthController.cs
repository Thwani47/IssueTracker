using IssueTracker.DataAccess.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public async IActionResult<LoginResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });
        
        
    }
}