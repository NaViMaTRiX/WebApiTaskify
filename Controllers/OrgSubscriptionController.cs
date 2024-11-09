namespace WebApiTaskify.Controllers;

using Dtos.OrgSubscription;
using Interface;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/v{version:apiVersion}/orgSubscription")]
[ApiController]
public class OrgSubscriptionController : ControllerBase
{
    private readonly IOrgSubscriptionRepository _orgSubscriptionRepository;

    public OrgSubscriptionController(IOrgSubscriptionRepository orgSubscriptionRepository)
    {
        _orgSubscriptionRepository = orgSubscriptionRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var orgSubscriptions = await _orgSubscriptionRepository.GetAllAsync();
        var result = orgSubscriptions.Select(x => x.ToOrgSubscriptionDto());
        return Ok(orgSubscriptions);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var orgSubscription = await _orgSubscriptionRepository.GetByIdAsync(id);
        if (orgSubscription is null)
            return NotFound("OrgSubscription not found");
        
        return Ok(orgSubscription.ToOrgSubscriptionDto());
    }

    [HttpPost("{orgId}")]
    public async Task<IActionResult> Create([FromBody] CreateOrgSubscriptionDto createOrgSubscriptionDto, string orgId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var orgSubscription = createOrgSubscriptionDto.ToOrgSubscriptionDtoFromCreate(orgId);
        var result = await _orgSubscriptionRepository.CreateAsync(orgSubscription);
        
        if (result is null)
            return BadRequest("Failed to create orgSubscription");
        
        return CreatedAtAction(nameof(GetById), new { id = result.id }, result.ToOrgSubscriptionDto());
    }
    
    //[HttpPut("{id:guid}")]

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var orgSubscription = await _orgSubscriptionRepository.DeleteAsync(id);
        
        if (orgSubscription is null)
            return NotFound("OrgSubscription not found");

        return NoContent();
    }
}