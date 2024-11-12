namespace WebApiTaskify.Mappers;

using Dtos.Board;
using Models;

public static class BoardMappers
{
    public static BoardDto ToBoardDto(this Board boardModel) // изпользуется для вывода данных на страницу
    {
        return new BoardDto
        {
            Id = boardModel.id,
            OrgId = boardModel.orgId,
            Title = boardModel.title,
            Lists = boardModel.Lists.Select(list => list?.ToBoardWithListDto()).ToList(),
            ImageId = boardModel.imageId,
            ImageFullUrl = boardModel.imageFullUrl,
            ImageUserName = boardModel.imageUserName,
            ImageThumbUrl = boardModel.imageThumbUrl,
            ImageLinkHtml = boardModel.imageLinkHTML,
            createdAt = boardModel.createdAt,
            updatedAt = boardModel.updatedAt,
            updatedBy = boardModel.updatedBy,
            createdBy = boardModel.createdBy,
        };
    }

    public static Board ToBoardFromCreate(this CreateBoardDto createBoardModel, string orgId) // изпользуется для получения данных из формы
    {
        return new Board
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

    public static Board ToBoardFromUpdate(this UpdateBoardDto updateBoardModel) // изпользуется для получения данных из формы
    {
        return new Board
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