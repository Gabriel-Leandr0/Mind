using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Presentation.Models;

public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public DateTime BornDt { get; set; }
    public string Role { get; set; }
    public string Biography { get; set; }
    public string UserImage { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedDt { get; set; }
    public bool Active { get; set; }
}