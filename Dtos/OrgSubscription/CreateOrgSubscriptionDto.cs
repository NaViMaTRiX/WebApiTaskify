namespace WebApiTaskify.Dtos.OrgSubscription;

using System.ComponentModel.DataAnnotations;

public class CreateOrgSubscriptionDto
{
    [Required]
    public string StripeCustomerId { get; set; } = string.Empty;
    [Required]
    public string StripeSubscriptionId { get; set; } = string.Empty;
    [Required]
    public string StripePriseId { get; set; } = string.Empty; // это пока не подключил Юкассу
}