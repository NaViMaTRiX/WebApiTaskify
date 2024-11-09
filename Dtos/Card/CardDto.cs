namespace WebApiTaskify.Dtos.Card;

using Models;

public class CardDto
{
    public string id { get; set; }
    public string title { get; set; }
    public int order { get; set; }
    public string listId { get; set; }
    public string? description { get; set; }
    public bool timeChecked { get; set; } //хз
    public bool readyChecked { get; set; } //хз
    public DateTime? timeStart { get; set; }
    public DateTime? timeEnd { get; set; }
    public DateTime createdAt { get; set; } 
    public DateTime updatedAt { get; set; }
}