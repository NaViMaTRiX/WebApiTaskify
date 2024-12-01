using System.Text.Json.Serialization;
using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Lists : BaseModel
{
    public Guid id { get; init; }
    public Guid? boardId { get; init; }
    public string? title { get; set; }
    public int? order { get; set; }
    
    
    public ICollection<Cards>? Cards { get; init; }
    [JsonIgnore]
    public Boards? Board { get; init; }
}