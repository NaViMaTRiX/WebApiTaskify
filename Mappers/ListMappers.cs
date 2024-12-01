namespace WebApiTaskify.Mappers;

using Dtos.List;
using Models;

public static class ListMappers
{
    public static ListDto ToListDto(this Lists listModel) // изпользуется длЯ вывода данных на страницу
    {
        return new ListDto
        {
            Id = listModel.id,
            BoardId = listModel.boardId,
            Title = listModel.title,
            Order = listModel.order,
            Cards = listModel.Cards.Select(x => x?.ToCardDto()).ToList(),
            createdTime = listModel.createdTime,
            lastModifyTime = listModel.lastModifyTime,
            createdUser = listModel.createdUser,
            lastModifyUser = listModel.lastModifyUser, // TODO: сделать вот это везде
        };
    }
    
    public static ListDto ToBoardWithListDto(this Lists listModel) // изпользуется длЯ вывода данных на страницу
    {
        return new ListDto
        {
            Id = listModel.id,
            BoardId = listModel.boardId,
            Title = listModel.title,
            Order = listModel.order,
            createdTime = listModel.createdTime,
            lastModifyTime = listModel.lastModifyTime,
            createdUser = listModel.createdUser,
            lastModifyUser = listModel.lastModifyUser, // TODO: сделать вот это везде
        };
    }

    // изпользуется для ввода данных на форму
    public static Lists ToListFromCreate(this CreateListDto createListModel, Guid boardId)
    {
        return new Lists
        {
            id = Guid.NewGuid(),
            boardId = boardId,
            title = createListModel.Title,
            order = createListModel.Order,
        };
    }

    public static Lists ToListFromUpdate(this UpdateListDto updateListModel)
    {
        return new Lists
        {
            title = updateListModel.Title,
            order = updateListModel.Order,
        };
    }
}