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
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var list = await _listRepository.GetByIdAsync(id);
        if (list is null)
            return NotFound();

        return Ok(list.ToListDto());
    }

    [HttpPost("{boardId:guid}")]
    public async Task<IActionResult> Create([FromRoute] Guid boardId, [FromBody] CreateListDto createListDto)
    {
         if (!ModelState.IsValid)
             return BadRequest(ModelState);

         if (!await _boardRepository.ExistAsync(boardId))
         {
             return BadRequest(ModelState);
         }

         var listModel = createListDto.ToListFromCreate(boardId);
         await _listRepository.CreateAsync(listModel);
         return CreatedAtAction(nameof(GetById), new { id = listModel.Id }, listModel.ToListDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateListDto updateListDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var checkList = await _listRepository.UpdateAsync(id, updateListDto.ToListFromUpdate());
        
        if (checkList is null)
            return NotFound("List not found");

        return Ok(checkList.ToListDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var checkList = await _listRepository.DeleteAsync(id);
        
        if (checkList is null)
            return NotFound("List not found");
        
        return Ok(checkList.ToListDto());
    }
    
}