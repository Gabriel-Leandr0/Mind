namespace Mind.Domain.DTos;

public class CreateUserDto
{
    public string UserName { get; set; }
    public string Cpf { get; set; }
    public DateTime BornDt { get; set; }
    public int RoleId { get; set; }
    public string Biography { get; set; }
    public string UserImage { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}