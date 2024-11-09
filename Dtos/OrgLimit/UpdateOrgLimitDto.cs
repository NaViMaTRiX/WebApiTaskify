namespace WebApiTaskify.Dtos.OrgLimit;

using System.ComponentModel.DataAnnotations;

public class UpdateOrgLimitDto
{
    [Required]
    public int Limit { get; set; } = 0;
}