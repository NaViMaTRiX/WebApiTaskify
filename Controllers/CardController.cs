namespace WebApiTaskify.Controllers;

using Dtos.Card;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Repository;

[ApiController]
[Route("api/v{version:apiVersion}/card")]
public class CardController : ControllerBase
{
    private readonly ICardRepository _cardRepository;
    private readonly IListRepository _listRepository;

    public CardController(ICardRepository cardRepository, IListRepository listRepository)
    {
        _cardRepository = cardRepository;
        _listRepository = listRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var cards = await _cardRepository.GetAllAsync();
        var result = cards.Select(x => x.ToCardDto());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var card = await _cardRepository.GetByIdAsync(id);
        if (card is null)
            return NotFound("Card not found");
        
        return Ok(card.ToCardDto());
    }

    [HttpPost("{listId:guid}")]
    public async Task<IActionResult> Create([FromBody] CreateCardDto createCardDto, Guid listId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        if(!await _listRepository.ExistAsync(listId))
            return BadRequest("List not found");
        
        var cardModel = createCardDto.ToCardFromCreate(listId);
        await _cardRepository.CreateAsync(cardModel);
        return CreatedAtAction(nameof(GetById), new { id = cardModel.Id }, cardModel.ToCardDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromBody] UpdateCardDto updateCardDto, Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var cardModel = await _cardRepository.UpdateAsync(id, updateCardDto.ToCardFromUpdate());
        
        if (cardModel is null)
            return NotFound("Card not found");
        
        return Ok(cardModel.ToCardDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var card = await _cardRepository.DeleteAsync(id);
        
        if (card is null)
            return NotFound("Card not found");
        
        return NoContent();
    }
}