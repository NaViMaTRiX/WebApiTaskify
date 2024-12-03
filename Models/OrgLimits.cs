using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class OrgLimits : BaseModel
{
    public Guid Id { get; init; }
    public string? OrgId { get; init; }
    public int? Count { get; set; }
}