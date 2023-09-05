using System.ComponentModel.DataAnnotations;

namespace Namespace;
public class ApiKeysTable
{
    [Key]
    [Required]
    public Guid Id;
    [Required]
    public Guid UserId;
    [Required]
    public Guid Key;
}
