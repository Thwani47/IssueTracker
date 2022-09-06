using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using IssueTracker.DataAccess.Models.Users;

#pragma warning disable CS8618
namespace IssueTracker.DataAccess.Models.Authentication;

[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public class RegisterRequest
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid name length")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid name length")]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid email length")]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "User type must be specified")]
    public UserType UserType { get; set; }
    
    [Required(ErrorMessage = "Username is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid username length")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid password length")]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "Confirm password is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Invalid password length")]
    public string ConfirmPassword { get; set; }
}