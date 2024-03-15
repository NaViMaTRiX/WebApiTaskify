namespace WebApiTaskify.Models;

// Пока что не понимаю, как правильно это реализовать
/*enum ACTION {
    CREATE,
    UPDATE,
    DELETE
}

enum ENTITY_TYPE {
    BOARD,
    LIST,
    CARD
}*/

public class AuditLogs
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string OrgId { get; set; } = string.Empty;
    public string Action { get; set; } = String.Empty; //TODO: enum CREATE, UPDATE, DELETE
    public string EntityId { get; set; } = String.Empty;
    public string EntityTitle { get; set; } = String.Empty;
    public string EntityType { get; set; } = String.Empty; // TODO: enum BOARD, LIST, CARD
    public string UserId { get; set; } = String.Empty;
    public string UserName { get; set; } = String.Empty;
    public string UserImage { get; set; } = String.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}