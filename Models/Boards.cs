using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Boards : BaseModel
{
    public Guid id { get; set; }
    public string orgId { get; set; }
    public string title { get; set; } 
    public string imageId { get; set; } 
    public string imageThumbUrl { get; set; } 
    public string imageFullUrl { get; set; } 
    public string imageUserName { get; set; } 
    public string imageLinkHTML { get; set; }
    
    public List<Lists>? lists { get; set; }
}