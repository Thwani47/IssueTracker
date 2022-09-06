namespace IssueTracker.DataAccess.Models.Team;

public class Team
{
    public Guid TeamId { get; set; }
#pragma warning disable CS8618
    public string TeamName { get; set; }
#pragma warning restore CS8618
    public Guid TeamLead { get; set; }
}