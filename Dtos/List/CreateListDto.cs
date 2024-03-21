namespace WebApiTaskify.Dtos.List;

using System.ComponentModel.DataAnnotations;

public class CreateListDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public int Order { get; set; } = 0;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}