namespace WebApiTaskify.Models;

public class Boards
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrgId { get; set; } = String.Empty; 
    public string Title { get; set; } = String.Empty;
    public string ImageId { get; set; } = String.Empty;
    public string ImageThumbUrl { get; set; } = String.Empty;
    public string ImageFullUrl { get; set; } = String.Empty;
    public string ImageUserName { get; set; } = String.Empty;
    public string ImageLinkHtml { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public List<Lists> Lists { get; set; } = new List<Lists>();
}