namespace WebApiTaskify.Dtos.OrgSubscription;

using System.ComponentModel.DataAnnotations;

public class CreateOrgSubscriptionDto
{
    [Required]
    public string StripeCustomerId { get; set; } = String.Empty;
    [Required]
    public string StripeSubscriptionId { get; set; } = String.Empty;
    [Required]
    public string StripePriseId { get; set; } = String.Empty; // это пока не подключил Юкассу
}