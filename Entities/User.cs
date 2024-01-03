using System.ComponentModel.DataAnnotations;

namespace LMS_Backend.Entities;
public class User
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

}