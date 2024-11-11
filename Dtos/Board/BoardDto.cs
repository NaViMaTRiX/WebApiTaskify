using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Dtos.Board;

public class BoardDto : BaseModel
{
    public Guid Id { get; set; }
    public string OrgId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImageId { get; set; } = string.Empty;
    public string ImageThumbUrl { get; set; } = string.Empty;
    public string ImageFullUrl { get; set; } = string.Empty;
    public string ImageUserName { get; set; } = string.Empty;
    public string ImageLinkHtml { get; set; } = string.Empty;
}