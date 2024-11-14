namespace WebApiTaskify.Mappers;

using Dtos.OrgLimit;
using Models;

public static class OrgMappers
{
    public static OrgLimitDto ToOrgLimitDto(this OrgLimits orgLimit)
    {
        return new OrgLimitDto
        {
            Id = orgLimit.id,
            OrgId = orgLimit.orgId,
            Limit = orgLimit.count,
            lastModifyTime = orgLimit.lastModifyTime,
            createdTime = orgLimit.createdTime,
            lastModifyUser = orgLimit.lastModifyUser,
            createdUser = orgLimit.createdUser,
        };
    }

    public static OrgLimits ToCreateFromOrgLimitDto(this CreateOrgLimitDto createOrgLimitDto, string orgId)
    {
        return new OrgLimits
        {
            id = Guid.NewGuid(),
            orgId = orgId,
            count = createOrgLimitDto.Limit,
        };
    }

    public static OrgLimits ToUpdateFromOrgLimitDto(this UpdateOrgLimitDto updateOrgLimitDto)
    {
        return new OrgLimits
        {
            count = updateOrgLimitDto.Limit,
        };
    }
}