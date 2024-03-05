using System.ComponentModel.DataAnnotations;

namespace Mind.Domain.Models;

public class Project
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [StringLength(80)]
    public string Title { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    public string ProjectImage { get; set; }

    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

}