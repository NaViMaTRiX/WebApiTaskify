using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Dtos.OrgSubscription;

public class OrgSubscriptionDto : BaseModel
{
    public Guid Id { get; set; }
    public string OrgId { get; set; }
    public string StripeCustomerId { get; set; }
    public string StripeSubscriptionId { get; set; }
    public string StripePriseId { get; set; } // это пока не подключил Юкассу
    public DateTime StripeCurrentPeriodEnd { get; set; } = DateTime.UtcNow;
}