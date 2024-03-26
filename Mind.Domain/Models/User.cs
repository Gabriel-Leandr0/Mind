using System.ComponentModel.DataAnnotations;

namespace Mind.Domain.Models;

public class User
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string Nickname { get; set; }
    public string Cpf { get; set; }
    public DateTime BornDt { get; set; }
    public int RoleId { get; set; }
    public virtual Role Role { get; set; }
    public string Biography { get; set; }
    public string UserImage { get; set; }
    public string Email { get; set; }
    public byte[] Password { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;
    public bool Active { get; set; } = true;
    public virtual ICollection<Project> Projects { get; set; }
}