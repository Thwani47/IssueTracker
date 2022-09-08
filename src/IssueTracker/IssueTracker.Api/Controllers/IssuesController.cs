using IssueTracker.Api.Services.IssueService;
using IssueTracker.DataAccess.Models;
using IssueTracker.DataAccess.Models.Issue;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class IssuesController : ControllerBase
{
    private readonly IIssueService _issueService;
    private readonly ILogger<IssuesController> _logger;

    public IssuesController(IIssueService issueService, ILogger<IssuesController> logger)
    {
        _issueService = issueService;
        _logger = logger;
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllIssues()
    {
        try
        {
            var result = await _issueService.DoGetAllIssues();

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

    [HttpGet("issueId/{issueId}")]
    public async Task<IActionResult> GetIssue(string issueId)
    {
        try
        {
            var result = await _issueService.DoGetIssueById(issueId);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { result.Message });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error fetching issue: {e.Message}");
            return BadRequest(new { Message = "Error fetching issue" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddNewIssue([FromBody] AddIssueRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });
        try
        {
            var result = await _issueService.DoAddNewIssue(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { Message = "Failed to add new issue" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error adding new issue: {e.Message}");
            return BadRequest(new { Message = "Error adding new issue" });
        }
    }

    [HttpPut("update-priority/issueId/{issueId}")]
    public async Task<IActionResult> UpdateIssuePriority([FromBody] UpdateIssuePriorityRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });
        try
        {
            var result = await _issueService.DoUpdateIssuePriority(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { Message = "Failed to update issue" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error updating issue: {e.Message}");
            return BadRequest(new { Message = "Error updating issue" });
        }
    }
    
    
    [HttpPut("update-assignee/issueId/{issueId}")]
    public async Task<IActionResult> UpdateIssueAssignee([FromBody] UpdateIssueAssigneeRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });
        try
        {
            var result = await _issueService.DoUpdateIssueAssignee(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { Message = "Failed to update issue" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error updating issue: {e.Message}");
            return BadRequest(new { Message = "Error updating issue" });
        }
    }
    
    [HttpPut("update-status/issueId/{issueId}")]
    public async Task<IActionResult> UpdateIssueStatus([FromBody] UpdateIssueStatusRequest request)
    {
        if (!ModelState.IsValid) return BadRequest(new { Message = "Invalid request" });
        try
        {
            var result = await _issueService.DoUpdateIssueStatus(request);

            if (result.Status == AuthRequestStatus.Failure)
            {
                return NotFound(new { Message = "Failed to update issue" });
            }

            return Ok(new { result.Message, result.Data });
        }
        catch (Exception e)
        {
            _logger.LogWarning($"Error updating issue: {e.Message}");
            return BadRequest(new { Message = "Error updating issue" });
        }
    }
}