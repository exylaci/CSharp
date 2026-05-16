using Api.Dtos;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailSubscriptionsController : ControllerBase
{
    private readonly IEmailSubscriptionService _service;

    public EmailSubscriptionsController(IEmailSubscriptionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<EmailAddressDto>>> GetAll()
    {
        List<EmailAddressDto> items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmailAddressDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        (bool success, string message) = await _service.CreateAsync(dto);
        if (!success)
        {
            return BadRequest(message);
        }

        return Ok(message);
    }
}