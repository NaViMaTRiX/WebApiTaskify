namespace WebApiTaskify.Models;

public class OrgLimit
{
    public string id { get; set; }
    public string orgId { get; set; }
    public int count { get; set; } 
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}