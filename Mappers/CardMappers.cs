namespace WebApiTaskify.Mappers;

using Dtos.Card;
using Models;

public static class CardMappers
{
    public static CardDto ToCardDto(this Cards cardDto)
    {
        return new CardDto
        {
            Id = cardDto.Id,
            Title = cardDto.Title,
            Description = cardDto.Description,
            Order = cardDto.Order,
            isChecked = cardDto.isChecked,
            CreatedAt = cardDto.CreatedAt,
            UpdatedAt = cardDto.UpdatedAt,
            ListId = cardDto.ListId
        };
    }

    public static Cards ToCardFromCreate(this CreateCardDto createCardDto, Guid listId)
    {
        return new Cards
        {
            Title = createCardDto.Title,
            Description = createCardDto.Description,
            Order = createCardDto.Order,
            CreatedAt = createCardDto.CreatedAt,
            UpdatedAt = createCardDto.UpdatedAt,
            isChecked = createCardDto.isChecked,
            ListId = listId
        };
    }

    public static Cards ToCardFromUpdate(this UpdateCardDto updateCardDto)
    {
        return new Cards
        {
            Title = updateCardDto.Title,
            Description = updateCardDto.Description,
            Order = updateCardDto.Order,
            UpdatedAt = updateCardDto.UpdatedAt,
            isChecked = updateCardDto.isChecked,
        };
    }
}