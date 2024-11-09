namespace WebApiTaskify.Dtos.Board;

using System.ComponentModel.DataAnnotations;

public class CreateBoardDto
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string ImageId { get; set; } = string.Empty;
    [Required]
    public string ImageFullUrl { get; set; } = string.Empty;
    [Required]
    public string ImageThumbUrl { get; set; } = string.Empty;
    [Required]
    public string ImageUserName { get; set; } =string.Empty;
    [Required]
    public string ImageLinkHtml { get; set; } = string.Empty;
}