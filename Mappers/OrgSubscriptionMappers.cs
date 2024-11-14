namespace WebApiTaskify.Mappers;

using Dtos.OrgSubscription;
using Models;

public static class OrgSubscriptionMappers
{
    public static OrgSubscriptionDto ToOrgSubscriptionDto(this OrgSubscriptions orgSubscription)
    {
        return new OrgSubscriptionDto
        {
            Id = orgSubscription.id,
            OrgId = orgSubscription.orgId,
            StripePriseId = orgSubscription.stripe_price_id,
            StripeCustomerId = orgSubscription.stripe_customer_id,
            StripeSubscriptionId = orgSubscription.stripe_subscription_id,
            StripeCurrentPeriodEnd = orgSubscription.stripe_current_period_end,
            createdUser = orgSubscription.createdUser,
            lastModifyUser = orgSubscription.lastModifyUser,
            createdTime = orgSubscription.createdTime,
            lastModifyTime = orgSubscription.lastModifyTime,
        };
    }

    public static OrgSubscriptions ToOrgSubscriptionDtoFromCreate(this CreateOrgSubscriptionDto createOrgSubscription, string orgId)
    {
        return new OrgSubscriptions
        {
            id = Guid.NewGuid(),
            orgId = orgId,
            stripe_price_id = createOrgSubscription.StripePriseId,
            stripe_customer_id = createOrgSubscription.StripeCustomerId,
            stripe_subscription_id = createOrgSubscription.StripeSubscriptionId,
        };
    }
}