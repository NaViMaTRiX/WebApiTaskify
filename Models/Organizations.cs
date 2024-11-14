using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Organizations : BaseModel
{
    public Guid id { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public string logo { get; set; }
    public string? website { get; set; }
    public string? email { get; set; }
    public string? phone { get; set; }
    public string? address { get; set; }
    public string? state { get; set; }
}