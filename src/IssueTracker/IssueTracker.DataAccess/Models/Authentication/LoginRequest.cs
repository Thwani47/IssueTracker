using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IssueTracker.DataAccess.Models.Authentication;

public class LoginRequest
{
    [Required(ErrorMessage = "Username is required")]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Invalid username length")]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Invalid password length")]
    [JsonIgnore]
    public string Password { get; set; }
}