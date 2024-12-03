using NpgsqlTypes;

namespace WebApiTaskify.Models.Enum;

public enum ENTITY_TYPE
{
    [PgName("BOARD")]
    BOARD,
    [PgName("LIST")]
    LIST,
    [PgName("CARD")]
    CARD
}