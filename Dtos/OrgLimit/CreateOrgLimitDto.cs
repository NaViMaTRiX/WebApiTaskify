namespace WebApiTaskify.Dtos.OrgLimit;

using System.ComponentModel.DataAnnotations;

public class CreateOrgLimitDto
{
    [Required]
    public string OrgId { get; set; } = String.Empty;
    [Required]
    public int Limit { get; set; } = 0;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}