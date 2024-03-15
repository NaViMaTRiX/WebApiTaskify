namespace WebApiTaskify.Models;

public class Lists
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public int Order { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public Boards? BoardId { get; set; } = new Boards();
    public List<Cards> Cards { get; set; } = new List<Cards>();
    
}