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
            UpdatedAt = listModel.UpdatedAt
        };
    }

    // изпользуется для ввода данных на форму
    public static Lists ToCreateListDto(this CreateListDto createListModel) 
    {
        return new Lists
        {
            Title = createListModel.Title,
            Order = createListModel.Order,
            CreatedAt = createListModel.CreatedAt,
            UpdatedAt = createListModel.UpdatedAt
        };
    }

    public static Lists ToUpdateListDto(this UpdateListDto updateListModel)
    {
        return new Lists
        {
            Title = updateListModel.Title,
            Order = updateListModel.Order,
            UpdatedAt = updateListModel.UpdatedAt
        };
    }
}