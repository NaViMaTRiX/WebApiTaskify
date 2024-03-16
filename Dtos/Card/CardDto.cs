namespace WebApiTaskify.Dtos.Card;

public class CardDto
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public int Order { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; // Возможно now будет создавать неволадки. Надо тестить.
    public bool isChecked { get; set; } = false;
}