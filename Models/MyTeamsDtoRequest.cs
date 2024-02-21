using BelgianLeague.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BelgianLeague.Models;

public class MyTeamsDtoRequest
{
    [Required]
    [NotNull]
    public int UserId { get; set; }
    [Required]
    [NotNull]
    public int TeamId { get; set; }

    [Required]
    [NotNull]
    public RequestActions Action {  get; set; }
}
