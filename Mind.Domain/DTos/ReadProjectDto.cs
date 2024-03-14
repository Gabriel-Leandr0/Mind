using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Domain.DTos;

public class ReadProjectDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ProjectImage { get; set; }
    public DateTime CreatedDt { get; set; }
    public int CategoryId { get; set; }
}