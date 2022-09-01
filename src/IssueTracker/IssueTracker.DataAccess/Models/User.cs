using System.Diagnostics.CodeAnalysis;
#pragma warning disable CS8618

namespace IssueTracker.DataAccess.Models;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public Guid TeamId { get; set; }
}