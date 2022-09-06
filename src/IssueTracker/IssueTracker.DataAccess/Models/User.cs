using System.Diagnostics.CodeAnalysis;
using IssueTracker.DataAccess.Models.Users;

#pragma warning disable CS8618

namespace IssueTracker.DataAccess.Models;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class User
{
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public UserType UserType { get; set; }
}