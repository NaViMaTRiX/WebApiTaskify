namespace WebApiTaskify.Dtos.OrgLimit;

public class UpdateOrgLimitDto
{
    public Guid OrgId { get; set; } = Guid.Empty;
    public int Limit { get; set; } = 0;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}