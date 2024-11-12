namespace WebApiTaskify.Mappers;

using Dtos.Card;
using Models;

public static class CardMappers
{
    public static CardDto ToCardDto(this Card cardDto)
    {
        return new CardDto
        {
            id = cardDto.id,
            listId = cardDto.listId,
            title = cardDto.title,
            description = cardDto.description,
            order = cardDto.order,
            readyChecked = cardDto.ready,
            timeStart = cardDto.timeStart,
            timeEnd = cardDto.timeEnd,
            timeChecked = cardDto.timer,
            createdAt = cardDto.createdAt,
            updatedAt = cardDto.updatedAt,
            updatedBy = cardDto.updatedBy,
            createdBy = cardDto.createdBy,
        };
    }

    public static Card ToCardFromCreate(this CreateCardDto createCardDto, Guid listId)
    {
        return new Card
        {
            id = Guid.NewGuid(),
            listId = listId,
            title = createCardDto.Title,
            description = createCardDto.Description,
            order = createCardDto.Order,
            timer = createCardDto.TimeChecked,
            ready = createCardDto.ReadyChecked,
            timeStart = createCardDto.TimeStart,
            timeEnd = createCardDto.TimeEnd,
        };
    }

    public static Card ToCardFromUpdate(this UpdateCardDto updateCardDto)
    {
        return new Card
        {
            title = updateCardDto.Title,
            description = updateCardDto.Description,
            order = updateCardDto.Order,
            ready = updateCardDto.ReadyChecked,
            timer = updateCardDto.TimeChecked,
            timeStart = updateCardDto.TimeStart,
            timeEnd = updateCardDto.TimeEnd,
        };
    }
}