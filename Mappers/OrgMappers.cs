namespace WebApiTaskify.Mappers;

using Dtos.OrgLimit;
using Models;

public static class OrgMappers
{
    public static OrgLimitDto ToOrgLimitDto(this OrgLimit orgLimit)
    {
        return new OrgLimitDto
        {
            Id = orgLimit.id,
            OrgId = orgLimit.orgId,
            Limit = orgLimit.count,
            updatedAt = orgLimit.updatedAt,
            createdAt = orgLimit.createdAt,
        };
    }

    public static OrgLimit ToCreateFromOrgLimitDto(this CreateOrgLimitDto createOrgLimitDto, string orgId)
    {
        return new OrgLimit
        {
            id = Guid.NewGuid(),
            orgId = orgId,
            count = createOrgLimitDto.Limit,
        };
    }

    public static OrgLimit ToUpdateFromOrgLimitDto(this UpdateOrgLimitDto updateOrgLimitDto)
    {
        return new OrgLimit
        {
            count = updateOrgLimitDto.Limit,
        };
    }
}