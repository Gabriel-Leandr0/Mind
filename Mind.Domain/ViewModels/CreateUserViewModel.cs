using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Domain.ViewModels
{
    public class CreateUserViewModel
    {
    public string UserName { get; set; }
    public string Cpf { get; set; }
    public DateTime BornDt { get; set; }
    public string IdRole { get; set; }
    public string Biography { get; set; }
    public string UserImage { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    }
}