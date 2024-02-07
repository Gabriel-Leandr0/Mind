using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mind.Presentation.Models;

public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int UserId { get; set; }

    [StringLength(80)]
    public string Username { get; set; }

    [StringLength(11)]
    public string Cpf { get; set; }

    public DateTime BornDt { get; set; }

    [ForeignKey("Roles")]
    public string RoleId { get; set; }

    [StringLength(250)]
    public string Biography { get; set; }

    public string UserImage { get; set; }
    
    [StringLength(80)]    
    public string Email { get; set; }

    [StringLength(80)]
    public byte[] Password { get; set; }

    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;

    public bool Active { get; set; } = true;
}