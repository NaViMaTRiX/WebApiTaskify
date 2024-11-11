using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Dtos.Card;

using Models;

public class CardDto : BaseModel
{
    public Guid id { get; set; }
    public string title { get; set; }
    public int order { get; set; }
    public Guid listId { get; set; }
    public string? description { get; set; }
    public bool timeChecked { get; set; } //хз
    public bool readyChecked { get; set; } //хз
    public DateTime? timeStart { get; set; }
    public DateTime? timeEnd { get; set; }
}