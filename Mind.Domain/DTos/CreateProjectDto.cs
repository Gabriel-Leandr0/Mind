using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Domain.DTos;

public class CreateProjectDto
{
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ProjectImage { get; set; }
    public int CategoryId { get; set; }
}