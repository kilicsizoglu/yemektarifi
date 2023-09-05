using System.ComponentModel.DataAnnotations;

namespace Namespace;
public class UsersTable
{
    [Key]
    [Required]
    public Guid Id;
    [Required]
    public string Name;
    [Required]
    public string Password;
}
