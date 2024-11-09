namespace WebApiTaskify.Models;

public class Card
{
    public string id { get; set; }
    public string title { get; set; } = string.Empty;
    public int order { get; set; }
    public string listId { get; set; }
    public string? description { get; set; } = string.Empty;
    public bool timer { get; set; } //хз
    public bool ready { get; set; } //хз
    public DateTime? timeStart { get; set; } 
    public DateTime? timeEnd { get; set; }
    public DateTime createdAt { get; set; } 
    public DateTime updatedAt { get; set; }
}