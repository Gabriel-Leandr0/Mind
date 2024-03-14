using System.ComponentModel.DataAnnotations;

namespace Mind.Domain.Models;

public class User
{
    [Key]
    [Required]
    public int Id { get; set; }

    [StringLength(80)]
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Username { get; set; }

    [StringLength(11)]
    [Required(ErrorMessage = "O campo cpf é obrigatório")]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
    public DateTime BornDt { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; }

    [StringLength(250)]
    public string Biography { get; set; }

    public string UserImage { get; set; }

    [StringLength(80)]
    public string Email { get; set; }

    [StringLength(80)]
    public string Password { get; set; }

    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;

    public bool Active { get; set; } = true;
    public virtual ICollection<Project> Projects { get; set; }
}