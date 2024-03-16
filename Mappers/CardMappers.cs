namespace WebApiTaskify.Mappers;

using Dtos.Card;
using Models;

public static class CardMappers
{
    public static Cards ToCardDto(this CardDto cardDto)
    {
        return new Cards
        {
            Id = cardDto.Id,
            Title = cardDto.Title,
            Description = cardDto.Description,
            Order = cardDto.Order,
            isChecked = cardDto.isChecked,
            CreatedAt = cardDto.CreatedAt,
            UpdatedAt = cardDto.UpdatedAt,
        };
    }

    public static CardDto ToCreateCardDto(this CreateCardDto createCardDto)
    {
        return new CardDto
        {
            Title = createCardDto.Title,
            Description = createCardDto.Description,
            Order = createCardDto.Order,
            CreatedAt = createCardDto.CreatedAt,
            UpdatedAt = createCardDto.UpdatedAt,
            isChecked = createCardDto.isChecked,
        };
    }

    public static CardDto ToUpdateCardDto(this UpdateCardDto updateCardDto)
    {
        return new CardDto
        {
            Title = updateCardDto.Title,
            Description = updateCardDto.Description,
            Order = updateCardDto.Order,
            UpdatedAt = updateCardDto.UpdatedAt,
            isChecked = updateCardDto.isChecked,
        };
    }
}