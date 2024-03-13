﻿namespace WebApiTaskify.Models;

public class OrgSubscriptions
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string OrgId { get; set; } = string.Empty;
    public string StripeCustomerId { get; set; } = string.Empty;
    public string StripeSubscriptionId { get; set; } = string.Empty;
    public string StripePriseId { get; set; } = string.Empty;
    public DateTime StripeCurrentPeriodEnd { get; set; } = DateTime.UtcNow;
}