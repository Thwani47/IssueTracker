using IssueTracker.Api.Services.TeamService;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Team;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class TeamController : ControllerBase
{
    private readonly ITeamService _teamService;
    private readonly ILogger<TeamController> _logger;

    public TeamController(ITeamService teamService, ILogger<TeamController> logger)
    {
        _teamService = teamService;
        _logger = logger;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllTeams()
    {
        try
        {
            var result = await _teamService.DoGetAllTeams();

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { result.Message });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error fetching all teams: {e.Message}");
            return BadRequest(new { Message = "Error fetching teams" });
        }
    }

    [HttpGet("teamId/{teamId}")]
    public async Task<IActionResult> GetTeam(string teamId)
    {
        try
        {
            var result = await _teamService.DoGetTeamById(teamId);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { result.Message });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error fetching team: {e.Message}");
            return BadRequest(new { Message = "Error fetching team" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddNewTeam([FromBody] AddTeamRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });
        try
        {
            var result = await _teamService.DoAddNewTeam(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { Message = "Failed to add new team" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error adding new team: {e.Message}");
            return BadRequest(new { Message = "Error adding new team" });
        }
    }
}