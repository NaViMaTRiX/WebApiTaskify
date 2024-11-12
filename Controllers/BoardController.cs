namespace WebApiTaskify.Controllers;

using Dtos.Board;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/board")]
[ApiController]
public class BoardController(IBoardRepository boardRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var boards = await boardRepository.GetAllAsync(token);
        var result = boards.Select(b => b.ToBoardDto());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var board = await boardRepository.GetByIdAsync(id, token);
        if (board is null)
            return NotFound("Board not found");
        
        return Ok(board.ToBoardDto());
    }

    [HttpPost("{orgId}")]
    public async Task<IActionResult> Create([FromRoute] string orgId, [FromBody] CreateBoardDto boardDto, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        // TODO: проверка orgId через станонный сервис. Получается нужно получать orgId из контроллера другого api.
        
        var boardModel = boardDto.ToBoardFromCreate(orgId);
        var board = await boardRepository.CreateAsync(orgId, boardModel, token);
        
        if (board is null)
            return BadRequest("Failed to create board");
        
        return CreatedAtAction(nameof(GetById), new { id = board.id }, board.ToBoardDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBoardDto boardDto, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var boardModel = await boardRepository.UpdateAsync(id, boardDto.ToBoardFromUpdate(), token);
        
        if (boardModel is null)
            return NotFound("Board is not exist!");
        
        return Ok(boardModel.ToBoardDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var boardModel = await boardRepository.DeleteAsync(id, token);
        
        if (boardModel is null)
            return NotFound("Board is not exist!");
        
        return NoContent();
    }
}