namespace WebApiTaskify.Dtos.OrgSubscription;

public class OrgSubscriptionDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrgId { get; set; } = String.Empty;
    public string StripeCustomerId { get; set; } = String.Empty;
    public string StripeSubscriptionId { get; set; } = String.Empty;
    public string StripePriseId { get; set; } = String.Empty; // это пока не подключил Юкассу
    public DateTime StripeCurrentPeriodEnd { get; set; } = DateTime.UtcNow;
}