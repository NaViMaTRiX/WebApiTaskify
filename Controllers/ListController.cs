namespace WebApiTaskify.Controllers;

using Dtos.List;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/list")]
[ApiController]
public class ListController : ControllerBase
{
    private readonly IListRepository _listRepository;
    private readonly IBoardRepository _boardRepository;

    public ListController(IListRepository listRepository, IBoardRepository boardRepository)
    {
        _listRepository = listRepository;
        _boardRepository = boardRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var lists = await _listRepository.GetAllAsync(); 
        var result = lists.Select(x => x.ToListDto());
        return Ok(lists);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var list = await _listRepository.GetByIdAsync(id);
        if (list is null)
            return NotFound();

        return Ok(list.ToListDto());
    }

    [HttpPost("{boardId}")]
    public async Task<IActionResult> Create([FromRoute] string boardId, [FromBody] CreateListDto createListDto)
    {
         if (!ModelState.IsValid)
             return BadRequest(ModelState);

         if (!await _boardRepository.ExistAsync(boardId))
         {
             return BadRequest(ModelState);
         }

         var listModel = createListDto.ToListFromCreate(boardId);
         var list = await _listRepository.CreateAsync(listModel);
         
         if (list is null)
             return BadRequest("Failed to create list");
         return CreatedAtAction(nameof(GetById), new { id = list.id }, list.ToListDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateListDto updateListDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var checkList = await _listRepository.UpdateAsync(id, updateListDto.ToListFromUpdate());
        
        if (checkList is null)
            return NotFound("List not found");

        return Ok(checkList.ToListDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id) //TODO: make full delete list with all cards
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var checkList = await _listRepository.DeleteAsync(id);
        
        if (checkList is null)
            return NotFound("List not found");
        
        return NoContent();
    }
    
}