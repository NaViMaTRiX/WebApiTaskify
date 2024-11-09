namespace WebApiTaskify.Models;

public class Board
{
    public string id { get; set; }
    public string orgId { get; set; }
    public string title { get; set; } 
    public string imageId { get; set; } 
    public string imageThumbUrl { get; set; } 
    public string imageFullUrl { get; set; } 
    public string imageUserName { get; set; } 
    public string imageLinkHTML { get; set; }
    public DateTime createdAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;
    
    public List<List> Lists { get; set; } = new List<List>();
}