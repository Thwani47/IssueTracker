using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable CS8618
namespace IssueTracker.DataAccess.Models.Authentication;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class LoginRequest
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid username length")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid password length")]
    public string Password { get; set; }
}