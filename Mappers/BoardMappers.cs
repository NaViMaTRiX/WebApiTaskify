namespace WebApiTaskify.Mappers;

using Dtos.Board;
using Models;

public static class BoardMappers
{
    public static BoardDto ToBoardDto(this Boards boardsModel) // изпользуется для вывода данных на страницу
    {
        return new BoardDto
        {
            Id = boardsModel.Id,
            OrgId = boardsModel.OrgId,
            Title = boardsModel.Title,
            ImageId = boardsModel.ImageId,
            ImageFullUrl = boardsModel.ImageFullUrl,
            ImageUserName = boardsModel.ImageUserName,
            ImageThumbUrl = boardsModel.ImageThumbUrl,
            ImageLinkHtml = boardsModel.ImageLinkHtml,
            CreatedAt = boardsModel.CreatedAt,
            UpdatedAt = boardsModel.UpdatedAt,
        };
    }

    public static Boards ToBoardFromCreate(this CreateBoardDto createBoardModel, Guid orgId) // изпользуется для получения данных из формы
    {
        return new Boards
        {
            OrgId = orgId,
            Title = createBoardModel.Title,
            ImageId = createBoardModel.ImageId,
            ImageFullUrl = createBoardModel.ImageFullUrl,
            ImageUserName = createBoardModel.ImageUserName,
            ImageThumbUrl = createBoardModel.ImageThumbUrl,
            ImageLinkHtml = createBoardModel.ImageLinkHtml,
            CreatedAt = createBoardModel.CreatedAt,
            UpdatedAt = createBoardModel.UpdatedAt,
        };
    }

    public static Boards ToBoardFromUpdate(this UpdateBoardDto updateBoardModel) // изпользуется для получения данных из формы
    {
        return new Boards
        {
            Title = updateBoardModel.Title,
            ImageId = updateBoardModel.ImageId,
            ImageFullUrl = updateBoardModel.ImageFullUrl,
            ImageUserName = updateBoardModel.ImageUserName,
            ImageThumbUrl = updateBoardModel.ImageThumbUrl,
            ImageLinkHtml = updateBoardModel.ImageLinkHtml,
            UpdatedAt = updateBoardModel.UpdatedAt,
        };
    }
}