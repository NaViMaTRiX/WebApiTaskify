namespace WebApiTaskify.Mappers;

using Dtos.Card;
using Models;

public static class CardMappers
{
    public static CardDto ToCardDto(this Cards cardDto)
    {
        return new CardDto
        {
            id = cardDto.Id,
            listId = cardDto.ListId,
            title = cardDto.Title,
            description = cardDto.Description,
            order = cardDto.Order,
            readyChecked = cardDto.Ready,
            timeStart = cardDto.TimeStart,
            timeEnd = cardDto.TimeEnd,
            timeChecked = cardDto.Timer,
            CreatedTime = cardDto.CreatedTime,
            LastModifyTime = cardDto.LastModifyTime,
            LastModifyUser = cardDto.LastModifyUser,
            CreatedUser = cardDto.CreatedUser,
        };
    }

    public static Cards ToCardFromCreate(this CreateCardDto createCardDto, Guid listId)
    {
        return new Cards
        {
            Id = Guid.NewGuid(),
            ListId = listId,
            Title = createCardDto.Title,
            Description = createCardDto.Description,
            Order = createCardDto.Order,
            Timer = createCardDto.TimeChecked,
            Ready = createCardDto.ReadyChecked,
            TimeStart = createCardDto.TimeStart,
            TimeEnd = createCardDto.TimeEnd,
        };
    }

    public static Cards ToCardFromUpdate(this UpdateCardDto updateCardDto)
    {
        return new Cards
        {
            Title = updateCardDto.Title,
            Description = updateCardDto.Description,
            Order = updateCardDto.Order,
            Ready = updateCardDto.ReadyChecked,
            Timer = updateCardDto.TimeChecked,
            TimeStart = updateCardDto.TimeStart,
            TimeEnd = updateCardDto.TimeEnd,
        };
    }
}