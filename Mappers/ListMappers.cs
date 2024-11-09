namespace WebApiTaskify.Mappers;

using Dtos.List;
using Models;

public static class ListMappers
{
    public static ListDto ToListDto(this List listModel) // изпользуется длЯ вывода данных на страницу
    {
        return new ListDto
        {
            Id = listModel.id,
            Title = listModel.title,
            Order = listModel.order,
            CreatedAt = listModel.createdAt,
            UpdatedAt = listModel.updatedAt,
            BoardId = listModel.boardId,
        };
    }

    // изпользуется для ввода данных на форму
    public static List ToListFromCreate(this CreateListDto createListModel, string boardId)
    {
        return new List
        {
            id = Guid.NewGuid().ToString(),
            boardId = boardId,
            title = createListModel.Title,
            order = createListModel.Order,
            createdAt = createListModel.CreatedAt,
            updatedAt = createListModel.UpdatedAt,
        };
    }

    public static List ToListFromUpdate(this UpdateListDto updateListModel)
    {
        return new List
        {
            title = updateListModel.Title,
            order = updateListModel.Order,
            updatedAt = updateListModel.UpdatedAt
        };
    }
}