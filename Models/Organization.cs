using WebApiTaskify.Models.Libs;

namespace WebApiTaskify.Models;

public class Organization : BaseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Logo { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? State { get; set; }
}