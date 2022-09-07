using System.ComponentModel.DataAnnotations;

namespace IssueTracker.DataAccess.Models.Issue;

public class UpdateIssueStatusRequest
{
    [Required(ErrorMessage = "Issue Id is required")]
    public Guid IssueId { get; set; }
    
    [Required(ErrorMessage = "Status is required")]
    public IssueStatus IssueStatus { get; set; }
}