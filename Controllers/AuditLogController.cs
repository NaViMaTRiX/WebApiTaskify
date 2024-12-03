﻿namespace WebApiTaskify.Controllers;

using Dtos.AuditLog;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v{version:apiVersion}/auditLog")]
public class AuditLogController(IAuditLogRepository auditLogRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var auditLogs = await auditLogRepository.GetAllAsync(token);
        var result = auditLogs.Select(x => x.ToAuditLogDto());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var auditLog = await auditLogRepository.GetByIdAsync(id, token);
        if (auditLog == null)
            return NotFound("Audit log not found");
        
        return Ok(auditLog.ToAuditLogDto());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAuditLogDto auditLogDto, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var auditLogModel = auditLogDto.ToAuditLogsFromCreate();
        var auditLog = await auditLogRepository.CreateAsync(auditLogModel, token);
        
        if (auditLog == null)
            return BadRequest("Failed to create audit log");
        
        return CreatedAtAction(nameof(GetById), new { id = auditLog.Id }, auditLog.ToAuditLogDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken token)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var auditLog = await auditLogRepository.DeleteAsync(id, token);

        if (auditLog is null)
            return NotFound("Audit log not found");
        
        return NoContent();
    }
}