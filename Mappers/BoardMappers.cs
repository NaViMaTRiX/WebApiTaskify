namespace WebApiTaskify.Mappers;

using Dtos.Board;
using Models;

public static class BoardMappers
{
    public static BoardDto ToBoardDto(this Boards boardModel) // изпользуется для вывода данных на страницу
    {
        return new BoardDto
        {
            Id = boardModel.id,
            OrgId = boardModel.orgId,
            Title = boardModel.title,
            Lists = boardModel.lists.Select(list => list?.ToBoardWithListDto()).ToList(),
            ImageId = boardModel.imageId,
            ImageFullUrl = boardModel.imageFullUrl,
            ImageUserName = boardModel.imageUserName,
            ImageThumbUrl = boardModel.imageThumbUrl,
            ImageLinkHtml = boardModel.imageLinkHTML,
            createdTime = boardModel.createdTime,
            lastModifyTime = boardModel.lastModifyTime,
            lastModifyUser = boardModel.lastModifyUser,
            createdUser = boardModel.createdUser,
        };
    }

    public static Boards ToBoardFromCreate(this CreateBoardDto createBoardModel, string orgId) // изпользуется для получения данных из формы
    {
        return new Boards
        {
            id = Guid.NewGuid(),
            orgId = orgId,
            title = createBoardModel.Title,
            imageId = createBoardModel.ImageId,
            imageFullUrl = createBoardModel.ImageFullUrl,
            imageUserName = createBoardModel.ImageUserName,
            imageThumbUrl = createBoardModel.ImageThumbUrl,
            imageLinkHTML = createBoardModel.ImageLinkHtml,
        };
    }

    public static Boards ToBoardFromUpdate(this UpdateBoardDto updateBoardModel) // изпользуется для получения данных из формы
    {
        return new Boards
        {
            orgId = updateBoardModel.OrgId,
            title = updateBoardModel.Title,
            imageId = updateBoardModel.ImageId,
            imageFullUrl = updateBoardModel.ImageFullUrl,
            imageUserName = updateBoardModel.ImageUserName,
            imageThumbUrl = updateBoardModel.ImageThumbUrl,
            imageLinkHTML = updateBoardModel.ImageLinkHtml,
        };
    }
}