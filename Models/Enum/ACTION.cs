using NpgsqlTypes;

namespace WebApiTaskify.Models.Enum;

public enum ACTION
{
    [PgName("UPDATE")]
    UPDATE,
    [PgName("CREATE")]
    CREATE,
    [PgName("DELETE")]
    DELETE
}
