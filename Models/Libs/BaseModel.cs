namespace WebApiTaskify.Models.Libs;

public abstract class BaseModel
{
    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime? updatedAt { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; } = null;
}