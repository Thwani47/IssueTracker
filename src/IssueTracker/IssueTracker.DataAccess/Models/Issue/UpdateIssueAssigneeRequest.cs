using System.ComponentModel.DataAnnotations;

namespace IssueTracker.DataAccess.Models.Issue;

public class UpdateIssueAssigneeRequest
{
    [Required(ErrorMessage = "Issue Id is required")]
    public Guid IssueId { get; set; }
    
    [Required(ErrorMessage = "Assignee Id is required")]
    public Guid AssigneeId { get; set; }
}