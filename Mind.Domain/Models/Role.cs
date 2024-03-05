using System.ComponentModel.DataAnnotations;

namespace Mind.Domain.Models;

public class Role
{
    [Key]
    [Required]
    public int Id { get; set; }

    [StringLength(80)]
    public string RoleName { get; set; }

    public virtual User User { get; set; } 
}