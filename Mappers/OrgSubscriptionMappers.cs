namespace WebApiTaskify.Mappers;

using Dtos.OrgSubscription;
using Models;

public static class OrgSubscriptionMappers
{
    public static OrgSubscriptionDto ToOrgSubscriptionDto(this OrgSubscriptions orgSubscription)
    {
        return new OrgSubscriptionDto
        {
            Id = orgSubscription.Id,
            OrgId = orgSubscription.OrgId,
            StripePriseId = orgSubscription.StripePriseId,
            StripeCustomerId = orgSubscription.StripeCustomerId,
            StripeSubscriptionId = orgSubscription.StripeSubscriptionId,
            StripeCurrentPeriodEnd = orgSubscription.StripeCurrentPeriodEnd,
        };
    }

    public static OrgSubscriptions ToOrgSubscriptionDtoFromCreate(this CreateOrgSubscriptionDto createOrgSubscription)
    {
        return new OrgSubscriptions
        {
            OrgId = createOrgSubscription.OrgId,
            StripePriseId = createOrgSubscription.StripePriseId,
            StripeCustomerId = createOrgSubscription.StripeCustomerId,
            StripeSubscriptionId = createOrgSubscription.StripeSubscriptionId,
            StripeCurrentPeriodEnd = createOrgSubscription.StripeCurrentPeriodEnd,
        };
    }
}