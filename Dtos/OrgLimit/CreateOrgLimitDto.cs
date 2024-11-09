namespace WebApiTaskify.Dtos.OrgLimit;

using System.ComponentModel.DataAnnotations;

public class CreateOrgLimitDto
{
    [Required]
    public int Limit { get; set; } = 0;
}