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
            StripePriseId = orgSubscription.StripePriceId,
            StripeCustomerId = orgSubscription.StripeCustomerId,
            StripeSubscriptionId = orgSubscription.StripeSubscriptionId,
            StripeCurrentPeriodEnd = orgSubscription.StripeCurrentPeriodEnd,
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
            StripePriceId = createOrgSubscription.StripePriseId,
            StripeCustomerId = createOrgSubscription.StripeCustomerId,
            StripeSubscriptionId = createOrgSubscription.StripeSubscriptionId,
        };
    }
}