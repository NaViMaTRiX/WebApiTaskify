namespace WebApiTaskify.Dtos.Board;

using System.ComponentModel.DataAnnotations;

public class CreateBoardDto
{
    [Required]
    public string OrgId { get; set; } = String.Empty;
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = String.Empty;
    [Required]
    public string ImageId { get; set; } = String.Empty;
    [Required]
    public string ImageFullUrl { get; set; } = String.Empty;
    [Required]
    public string ImageThumbUrl { get; set; } = String.Empty;
    [Required]
    public string ImageUserName { get; set; } =String.Empty;
    [Required]
    public string ImageLinkHtml { get; set; } = String.Empty;
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}