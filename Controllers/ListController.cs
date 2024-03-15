namespace WebApiTaskify.Controllers;

using Dtos.List;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Repository;

[Route("api/v{version:apiVersion}/list")]
[ApiController]
public class ListController : ControllerBase
{
    private readonly ListRepository _repository;

    public ListController(ListRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var lists = await _repository.GetAllAsync();
        var result = lists.Select(x => x.ToListDto());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var list = await _repository.GetByIdAsync(id);
        if (list == null)
            return NotFound();

        var result = list.ToListDto();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromRoute] Guid boardId, [FromBody] CreateListDto createListDto)
    {
         if (!ModelState.IsValid)
             return BadRequest(ModelState);

         var listModel = createListDto.ToCreateListDto();
         await _repository.CreateAsync(boardId, listModel);
         return CreatedAtAction(nameof(GetById), new { id = listModel.Id }, listModel.ToListDto());
    }

    [HttpPut()]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateListDto updateListDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var checkList = await _repository.GetByIdAsync(id);
        
        if (checkList is null)
            return NotFound("List not found");
        
        await _repository.UpdateAsync(id, updateListDto.ToUpdateListDto());

        return Ok(checkList.ToListDto());
    }

    [HttpDelete()]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var checkList = await _repository.GetByIdAsync(id);
        
        if (checkList is null)
            return NotFound("List not found");
        
        await _repository.DeleteAsync(id);
        return Ok(checkList.ToListDto());
    }
    
}