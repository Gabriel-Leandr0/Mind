namespace Mind.Domain.DTos.User;

public class CreateUserDto
{
    public string Fullname { get; set; }
    public string Nickname { get; set; }
    public string Cpf { get; set; }
    public DateTime BornDt { get; set; }
    public int RoleId { get; set; }
    public string Biography { get; set; }
    public string UserImage { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}