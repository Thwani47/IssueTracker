using System.Diagnostics.CodeAnalysis;
#pragma warning disable CS8618

namespace IssueTracker.DataAccess.Models.Team;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Team
{
    public Guid TeamId { get; set; }
    public string TeamName { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}