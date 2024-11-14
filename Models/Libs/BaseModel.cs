using System.ComponentModel.DataAnnotations;

namespace WebApiTaskify.Models.Libs;

public abstract class BaseModel
{
    [Required]
    public DateTime createdTime { get; set; } = DateTime.UtcNow;
    public DateTime? lastModifyTime { get; set; } = DateTime.UtcNow;
    public string createdUser { get; set; } = string.Empty;
    public string? lastModifyUser { get; set; } = string.Empty;
}