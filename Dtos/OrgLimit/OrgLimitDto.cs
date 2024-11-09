namespace WebApiTaskify.Dtos.OrgLimit;

public class OrgLimitDto
{
    public string Id { get; set; } = string.Empty;
    public string OrgId { get; set; } = String.Empty;
    public int Limit { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}