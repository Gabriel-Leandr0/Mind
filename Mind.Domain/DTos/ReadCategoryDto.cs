using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Domain.DTos;

public class ReadCategoryDto
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public DateTime CreatedDt { get; set; }
}