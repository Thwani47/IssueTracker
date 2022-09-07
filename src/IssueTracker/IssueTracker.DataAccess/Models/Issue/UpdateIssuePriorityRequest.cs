using System.ComponentModel.DataAnnotations;

namespace IssueTracker.DataAccess.Models.Issue;

public class UpdateIssuePriorityRequest
{
    [Required(ErrorMessage = "Issue Id is required")]
    public Guid IssueId { get; set; }
    
    [Required(ErrorMessage = "Priority is required")]
    public IssuePriority IssuePriority { get; set; }
}