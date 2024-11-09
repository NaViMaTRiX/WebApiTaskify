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
    public bool TimeChecked { get; set; } //хз
    [Required] 
    public bool ReadyChecked { get; set; } //хз
    public DateTime? TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }
}