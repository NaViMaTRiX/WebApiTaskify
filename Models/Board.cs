using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Board : BaseModel
{
    public Guid id { get; set; }
    public string orgId { get; set; }
    public string title { get; set; } 
    public string imageId { get; set; } 
    public string imageThumbUrl { get; set; } 
    public string imageFullUrl { get; set; } 
    public string imageUserName { get; set; } 
    public string imageLinkHTML { get; set; }
    
    public List<List> Lists { get; set; } = new List<List>();
}