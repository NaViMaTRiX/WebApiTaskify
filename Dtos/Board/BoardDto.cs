using WebApiTaskify.Dtos.List;
using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Dtos.Board;

public class BoardDto : BaseModel
{
    public Guid Id { get; set; }
    public string? OrgId { get; set; }
    public string? Title { get; set; }
    public string? ImageId { get; set; }
    public string? ImageThumbUrl { get; set; }
    public string? ImageFullUrl { get; set; }
    public string? ImageLinkHtml { get; set; }
    public ICollection<ListDto?> Lists { get; set; } = new List<ListDto?>();
}