using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Domain.DTos;

public class ReadUserDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Cpf { get; set; }
    public DateTime BornDt { get; set; }
    public int RoleId { get; set; }
    public string Biography { get; set; }
    public string UserImage { get; set; }
    public string Email { get; set; }
}