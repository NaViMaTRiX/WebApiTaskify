using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class OrgSubscriptions : BaseModel
{
    public Guid Id { get; init; }
    public string? OrgId { get; init; }
    public string? StripeCustomerId { get; init; }
    public string? StripeSubscriptionId { get; init; }
    public string? StripePriceId { get; init; }
    public DateTime? StripeCurrentPeriodEnd { get; init; } = DateTime.UtcNow;
}