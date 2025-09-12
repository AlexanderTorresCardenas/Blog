using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Blog.Entities;

public class Usuario : IdentityUser
{
    [Required]
    public string Nombre { get; set; } = string.Empty;
}
