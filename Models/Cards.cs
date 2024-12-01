using System.Text.Json.Serialization;
using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Cards : BaseModel
{
    public Guid id { get; set; }
    public string? title { get; set; }
    public int? order { get; set; }
    public Guid? listId { get; init; }
    public string? description { get; set; }
    public bool? timer { get; set; } // таймер есть или нету
    public bool? ready { get; set; } // непомню
    public DateTime? timeStart { get; set; } 
    public DateTime? timeEnd { get; set; }

    [JsonIgnore]
    public Lists? List { get; init; }
}