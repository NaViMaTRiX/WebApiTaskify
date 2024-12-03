using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Dtos.Card;

using Models;

public class CardDto : BaseModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public int? Order { get; set; }
    public Guid? ListId { get; set; }
    public string? Description { get; set; }
    public bool? TimeChecked { get; set; }
    public bool? ReadyChecked { get; set; }
    public DateTime? TimeStart { get; set; }
    public DateTime? TimeEnd { get; set; }
}