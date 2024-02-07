using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Presentation.Models;

public class Projects
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProjectId { get; set; }

    [ForeignKey("Users")]
    public int UserId { get; set; }
    
    [StringLength(80)]
    public string Title { get; set; }
    
    [StringLength(250)]
    public string Description { get; set; }
    public string ProjectImage { get; set; }
    public string ProjectUrl { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;

}