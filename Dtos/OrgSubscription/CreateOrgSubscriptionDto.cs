namespace WebApiTaskify.Dtos.OrgSubscription;

public class CreateOrgSubscriptionDto
{
    public Guid OrgId { get; set; } = Guid.Empty;
    public string StripeCustomerId { get; set; } = string.Empty;
    public string StripeSubscriptionId { get; set; } = string.Empty;
    public string StripePriseId { get; set; } = string.Empty; // это пока не подключил Юкассу
    public DateTime StripeCurrentPeriodEnd { get; set; } = DateTime.UtcNow;
}