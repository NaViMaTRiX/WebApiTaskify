namespace WebApiTaskify.Models;

public class List
{
    public string id { get; set; }
    public string title { get; set; }
    public int order { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public string boardId { get; set; }
    public List<Card> cards { get; set; } = new List<Card>();
    
}