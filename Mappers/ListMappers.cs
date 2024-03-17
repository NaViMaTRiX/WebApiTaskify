namespace WebApiTaskify.Mappers;

using Dtos.List;
using Models;

public static class ListMappers
{
    public static ListDto ToListDto(this Lists listModel) // изпользуется длЯ вывода данных на страницу
    {
        return new ListDto
        {
            Id = listModel.Id,
            Title = listModel.Title,
            Order = listModel.Order,
            CreatedAt = listModel.CreatedAt,
            UpdatedAt = listModel.UpdatedAt,
            BoardId = listModel.BoardId,
        };
    }

    // изпользуется для ввода данных на форму
    public static Lists ToListFromCreate(this CreateListDto createListModel, Guid boardId)
    {
        return new Lists
        {
            Title = createListModel.Title,
            Order = createListModel.Order,
            CreatedAt = createListModel.CreatedAt,
            UpdatedAt = createListModel.UpdatedAt,
            BoardId = boardId,
        };
    }

    public static Lists ToListFromUpdate(this UpdateListDto updateListModel)
    {
        return new Lists
        {
            Title = updateListModel.Title,
            Order = updateListModel.Order,
            UpdatedAt = updateListModel.UpdatedAt
        };
    }
}