namespace WebApiTaskify.Dtos.Card;

using System.ComponentModel.DataAnnotations;

public class UpdateCardDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(30)]
    public string Title { get; set; }
    [Required]
    public int Order { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(300)]
    public string Description { get; set; }
    [Required] 
    public bool TimeChecked { get; set; } //хз
    [Required] 
    public bool ReadyChecked { get; set; } //хз
    public DateTime? TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Возможно now будет создавать неполадки. Надо тестить.
}