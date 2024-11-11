namespace WebApiTaskify.Models.Libs;

public abstract class BaseModel
{
    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime? updatedAt { get; set; } = DateTime.UtcNow;
    public string createdBy { get; set; } = string.Empty;
    public string? updatedBy { get; set; } = string.Empty;
}