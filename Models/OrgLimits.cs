namespace WebApiTaskify.Models;

public class OrgLimits
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string OrgId { get; set; } = string.Empty;
    public int Limit { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}