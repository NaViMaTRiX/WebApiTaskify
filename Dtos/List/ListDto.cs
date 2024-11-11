using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Dtos.List;

public class ListDto : BaseModel
{
    public Guid Id { get; set; } 
    public Guid BoardId { get; set; } 
    public string Title { get; set; } 
    public int Order { get; set; } 

}