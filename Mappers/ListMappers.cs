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
            BoardId = listModel.boardId,
            Title = listModel.title,
            Order = listModel.order,
            Cards = listModel.cards.Select(x => x?.ToCardDto()).ToList(),
            createdAt = listModel.createdAt,
            updatedAt = listModel.updatedAt,
            createdBy = listModel.createdBy,
            updatedBy = listModel.updatedBy, // TODO: сделать вот это везде
        };
    }
    
    public static ListDto ToBoardWithListDto(this List listModel) // изпользуется длЯ вывода данных на страницу
    {
        return new ListDto
        {
            Id = listModel.id,
            BoardId = listModel.boardId,
            Title = listModel.title,
            Order = listModel.order,
            createdAt = listModel.createdAt,
            updatedAt = listModel.updatedAt,
            createdBy = listModel.createdBy,
            updatedBy = listModel.updatedBy, // TODO: сделать вот это везде
        };
    }

    // изпользуется для ввода данных на форму
    public static List ToListFromCreate(this CreateListDto createListModel, Guid boardId)
    {
        return new List
        {
            id = Guid.NewGuid(),
            boardId = boardId,
            title = createListModel.Title,
            order = createListModel.Order,
        };
    }

    public static List ToListFromUpdate(this UpdateListDto updateListModel)
    {
        return new List
        {
            title = updateListModel.Title,
            order = updateListModel.Order,
        };
    }
}