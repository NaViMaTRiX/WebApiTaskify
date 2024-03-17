namespace WebApiTaskify.Mappers;

using Dtos.OrgLimit;
using Models;

public static class OrgMappers
{
    public static OrgLimitDto ToOrgLimitDto(this OrgLimits orgLimit)
    {
        return new OrgLimitDto
        {
            Id = orgLimit.Id,
            OrgId = orgLimit.OrgId,
            Limit = orgLimit.Limit,
            UpdatedAt = orgLimit.UpdatedAt,
            CreatedAt = orgLimit.CreatedAt,
        };
    }

    public static OrgLimits ToCreateFromOrgLimitDto(this CreateOrgLimitDto createOrgLimitDto, Guid orgId)
    {
        return new OrgLimits
        {
            OrgId = orgId,
            Limit = createOrgLimitDto.Limit,
            CreatedAt = createOrgLimitDto.CreatedAt,
            UpdatedAt = createOrgLimitDto.UpdatedAt,
        };
    }

    public static OrgLimits ToCreateFromOrgLimitDto(this UpdateOrgLimitDto updateOrgLimitDto)
    {
        return new OrgLimits
        {
            OrgId = updateOrgLimitDto.OrgId,
            Limit = updateOrgLimitDto.Limit,
            UpdatedAt = updateOrgLimitDto.UpdatedAt,
        };
    }
}