namespace WebApiTaskify.Dtos.List;

using System.ComponentModel.DataAnnotations;

public class UpdateListDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public int Order { get; set; } = 0;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}