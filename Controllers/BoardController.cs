﻿namespace WebApiTaskify.Controllers;

using Asp.Versioning;
using Dtos.Board;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/board")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly IBoardRepository _boardRepository;

    public BoardController(IBoardRepository boardRepository)
    {
        _boardRepository = boardRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var boards = await _boardRepository.GetAllAsync();
        var result = boards.Select(b => b.ToBoardDto());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var board = await _boardRepository.GetByIdAsync(id);
        if (board is null)
            return NotFound("Board not found");
        
        return Ok(board.ToBoardDto());
    }

    [HttpPost("{id:guid}")]
    public async Task<IActionResult> Create([FromRoute] string orgId, [FromBody] CreateBoardDto boardDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        // TODO: проверка orgId через станонный сервис. Получается нужно получать orgId из контроллера другого api.
        
        var boardModel = boardDto.ToBoardFromCreate(orgId);
        await _boardRepository.CreateAsync(boardModel);
        return CreatedAtAction(nameof(GetById), new { id = boardModel.Id }, boardModel.ToBoardDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateBoardDto boardDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var boardModel = await _boardRepository.UpdateAsync(id, boardDto.ToBoardFromUpdate());
        
        if (boardModel is null)
            return NotFound("Board is not exist!");
        
        return Ok(boardModel.ToBoardDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var boardModel = await _boardRepository.DeleteAsync(id);
        
        if (boardModel is null)
            return NotFound("Board is not exist!");
        
        return Ok(boardModel.ToBoardDto());
    }
}