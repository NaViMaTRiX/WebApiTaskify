using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class List : BaseModel
{
    public Guid id { get; set; }
    public Guid boardId { get; set; }
    public string title { get; set; }
    public int order { get; set; }
    
    public ICollection<Card?> cards { get; set; }
}