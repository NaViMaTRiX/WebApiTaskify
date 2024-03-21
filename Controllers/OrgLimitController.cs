namespace WebApiTaskify.Controllers;

using Dtos.OrgLimit;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/orglimit")]
[ApiController]
public class OrgLimitController : ControllerBase
{
    private readonly IOrgLimitRepository _orgLimitRepository;
    public OrgLimitController(IOrgLimitRepository orgLimitRepository)
    {
        _orgLimitRepository = orgLimitRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var orgLimits = await _orgLimitRepository.GetAllAsync();                                 
        var result = orgLimits.Select(x => x.ToOrgLimitDto());
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var orgLimit = await _orgLimitRepository.GetByIdAsync(id);
        
        if(orgLimit is null)
            return NotFound("Organization limit not found");
        
        return Ok(orgLimit.ToOrgLimitDto());
    }

    [HttpPost("{orgId}")]
    public async Task<IActionResult> Create([FromBody] CreateOrgLimitDto createOrgLimitDto, string orgId)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var orgLimitModel = createOrgLimitDto.ToCreateFromOrgLimitDto(orgId);
        var orgLimit = await _orgLimitRepository.CreateAsync(orgLimitModel);
        
        if(orgLimit is null)
            return BadRequest("Organization limit could not be created");
        return CreatedAtAction(nameof(GetById), new {id = orgLimit.Id}, orgLimit.ToOrgLimitDto());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update([FromBody] UpdateOrgLimitDto updateOrgLimitDto, Guid id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var orgLimit = updateOrgLimitDto.ToCreateFromOrgLimitDto();
        var result = await _orgLimitRepository.UpdateAsync(id, orgLimit);
        
        if(result is null)
            return NotFound("Organization limit not found");
        
        return Ok(result.ToOrgLimitDto());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] Guid id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var result = await _orgLimitRepository.DeleteAsync(id);
        if(result is null)
            return NotFound("Organization limit not found");
        
        return NoContent();
    }
}