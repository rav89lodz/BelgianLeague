using System.ComponentModel.DataAnnotations;

namespace BelgianLeague.Models;

public class LoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [MinLength(5)]
    public string Password { get; set; }
}
