using System.Diagnostics.CodeAnalysis;

// ReSharper disable ClassNeverInstantiated.Global

#pragma warning disable CS8618

namespace IssueTracker.DataAccess.Models.Issue;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class Issue
{
    public Guid IssueId { get; set; }
    public string IssueTitle { get; set; }
    public string IssueDescription { get; set; }
    public IssuePriority IssuePriority { get; set; }
    public IssueStatus IssueStatus { get; set; }
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
}