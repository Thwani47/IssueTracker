using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace IssueTracker.DataAccess.Models.Products;

public class AddProductRequest
{
    [Required(ErrorMessage = "Team name is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid team name length")]
    public string ProductName { get; set; }
    
    [Required(ErrorMessage = "Team Lead Id is required")]
    public Guid TeamId { get; set; }

}