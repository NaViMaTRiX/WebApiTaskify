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
            updatedAt = cardDto.updatedAt
        };
    }

    public static Card ToCardFromCreate(this CreateCardDto createCardDto, string listId)
    {
        return new Card
        {
            id = Guid.NewGuid().ToString(),
            listId = listId,
            title = createCardDto.Title,
            description = createCardDto.Description,
            order = createCardDto.Order,
            timer = createCardDto.TimeChecked,
            ready = createCardDto.ReadyChecked,
            timeStart = createCardDto.CreatedAt,
            timeEnd = createCardDto.UpdatedAt,
            createdAt = createCardDto.CreatedAt,
            updatedAt = createCardDto.UpdatedAt,
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
            updatedAt = updateCardDto.UpdatedAt,
        };
    }
}