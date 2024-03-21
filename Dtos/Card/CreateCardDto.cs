namespace WebApiTaskify.Dtos.Card;

using System.ComponentModel.DataAnnotations;

public class CreateCardDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public int Order { get; set; } = 0;
    [Required]
    [MinLength(3)]
    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;
    [Required]
    public bool isChecked { get; set; } = false;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Возможно now будет создавать неполадки. Надо тестить.
}