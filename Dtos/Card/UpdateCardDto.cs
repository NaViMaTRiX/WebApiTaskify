namespace WebApiTaskify.Dtos.Card;

public class UpdateCardDto
{
    public string Title { get; set; } = string.Empty;
    public int Order { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; //TODO: Возможно now будет создавать неволадки. Надо тестить.
    public bool isChecked { get; set; } = false;
}