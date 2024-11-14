using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class OrgSubscriptions : BaseModel
{
    public Guid id { get; set; }
    public string? orgId { get; set; }
    public string stripe_customer_id { get; set; }
    public string stripe_subscription_id { get; set; }
    public string stripe_price_id { get; set; }
    public DateTime stripe_current_period_end { get; set; } = DateTime.UtcNow;
}