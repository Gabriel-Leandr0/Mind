using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Presentation.Models;

public class ProjectsCategories
{
    [ForeignKey("Projects")]
    public int IdProject { get; set; }
    
    [ForeignKey("Categories")]
    public int IdCategory{ get; set; }
}