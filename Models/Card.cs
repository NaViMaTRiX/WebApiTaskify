using System.Text.Json.Serialization;
using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Card : BaseModel
{
    public Guid id { get; set; }
    public string title { get; set; } = string.Empty;
    public int order { get; set; }
    public Guid listId { get; set; }
    public string? description { get; set; } = string.Empty;
    public bool timer { get; set; } //хз
    public bool ready { get; set; } //хз
    public DateTime? timeStart { get; set; } 
    public DateTime? timeEnd { get; set; }
}