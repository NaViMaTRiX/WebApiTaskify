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

    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var orgLimit = await _orgLimitRepository.GetByIdAsync(id);
        
        if(orgLimit is null)
            return NotFound("Org limit not found");
        
        return Ok(orgLimit.ToOrgLimitDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrgLimitDto createOrgLimitDto, Guid orgId)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var orgLimit = createOrgLimitDto.ToCreateFromOrgLimitDto(orgId);
        await _orgLimitRepository.CreateAsync(orgLimit);
        return CreatedAtAction(nameof(GetById), new {id = orgLimit.Id}, orgLimit.ToOrgLimitDto());
    }
}