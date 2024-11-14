using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Lists : BaseModel
{
    public Guid id { get; set; }
    public Guid? boardId { get; set; }
    public string title { get; set; }
    public int? order { get; set; }
    public List<Cards>? cards { get; set; } //TODO поменять всезде на List
}