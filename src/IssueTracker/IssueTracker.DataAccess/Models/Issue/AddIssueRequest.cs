using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace IssueTracker.DataAccess.Models.Issue;

public class AddIssueRequest
{
    [Required(ErrorMessage = "Issue title is required")]
    public string IssueTitle { get; set; }
    
    [Required(ErrorMessage = "Issue description is required")]
    public string IssueDescription { get; set; }
    
    [Required(ErrorMessage = "Product id is required")]
    public Guid ProductId { get; set; }
    
    [Required(ErrorMessage = "Issue priority is required")]
    public IssuePriority IssuePriority { get; set; }
    
    [Required(ErrorMessage = "Assignee Id is required")]
    public Guid AssignedTo { get; set; }
}