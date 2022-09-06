using System.ComponentModel.DataAnnotations;

namespace IssueTracker.DataAccess.Models.Team;

public class AddTeamRequest
{
#pragma warning disable CS8618
    [Required(ErrorMessage = "Team name is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid team name length")]
    public string TeamName { get; set; }
    
    [Required(ErrorMessage = "Team Lead Id is required")]
    public Guid TeamLead { get; set; }
#pragma warning restore CS8618
}