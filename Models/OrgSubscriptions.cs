﻿namespace WebApiTaskify.Models;

public class OrgSubscriptions
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrgId { get; set; } = Guid.Empty;
    public string StripeCustomerId { get; set; } = string.Empty;
    public string StripeSubscriptionId { get; set; } = string.Empty;
    public string StripePriseId { get; set; } = string.Empty;
    public DateTime StripeCurrentPeriodEnd { get; set; } = DateTime.UtcNow;
}