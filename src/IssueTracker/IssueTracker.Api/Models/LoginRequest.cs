using System.ComponentModel.DataAnnotations;

namespace IssueTracker.Api.Models;

public class LoginRequest
{
    [Required]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Invalid length for username")]
    public string Username { get; set; }
    
    [Required]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Invalid Password Length")]
    public string Password { get; set; }
}