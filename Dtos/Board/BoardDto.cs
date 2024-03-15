namespace WebApiTaskify.Dtos.Board;

public class BoardDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string OrgId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string ImageId { get; set; } = string.Empty;
    public string ImageThumbUrl { get; set; } = string.Empty;
    public string ImageFullUrl { get; set; } = string.Empty;
    public string ImageUserName { get; set; } = string.Empty;
    public string ImageLinkHtml { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}