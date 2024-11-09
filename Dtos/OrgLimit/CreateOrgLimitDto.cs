namespace WebApiTaskify.Dtos.OrgLimit;

using System.ComponentModel.DataAnnotations;

public class CreateOrgLimitDto
{
    [Required]
    public int Limit { get; set; } = 0;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}