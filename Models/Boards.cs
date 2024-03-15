namespace WebApiTaskify.Models;

public class Boards
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OrgId { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string ImageId { get; set; } = string.Empty;
    public string ImageThumbUrl { get; set; } = string.Empty;
    public string ImageFullUrl { get; set; } = string.Empty;
    public string ImageUserName { get; set; } = string.Empty;
    public string ImageLinkHtml { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public List<Lists> Lists { get; set; } = new List<Lists>();
}