using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class OrgSubscriptions : BaseModel
{
    public Guid id { get; set; }
    public string? orgId { get; set; }
    public string? StripeCustomerId { get; set; }
    public string? StripeSubscriptionId { get; set; }
    public string? StripePriceId { get; set; }
    public DateTime? StripeCurrentPeriodEnd { get; set; } = DateTime.UtcNow;
}