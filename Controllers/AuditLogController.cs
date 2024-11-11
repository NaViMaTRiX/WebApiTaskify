namespace WebApiTaskify.Controllers;

using Dtos.AuditLog;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v{version:apiVersion}/auditLog")]
public class AuditLogController : ControllerBase
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogController(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var auditLogs = await _auditLogRepository.GetAllAsync();
        var result = auditLogs.Select(x => x.ToAuditLogDto());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var auditLog = await _auditLogRepository.GetByIdAsync(id);
        if (auditLog == null)
            return NotFound("Audit log not found");
        
        return Ok(auditLog.ToAuditLogDto());
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAuditLogDto auditLogDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var auditLogModel = auditLogDto.ToAuditLogsFromCreate();
        var auditLog = await _auditLogRepository.CreateAsync(auditLogModel);
        
        if (auditLog == null)
            return BadRequest("Failed to create audit log");
        
        return CreatedAtAction(nameof(GetById), new { id = auditLog.id }, auditLog.ToAuditLogDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var auditLog = await _auditLogRepository.DeleteAsync(id);

        if (auditLog is null)
            return NotFound("Audit log not found");
        
        return NoContent();
    }
}