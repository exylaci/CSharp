using Api.Dtos;
using Api.Dtos.Results;
using Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]     //A [controler] helyére az osztály neve kerül Controller nélkül
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        return Ok(await _service.GetAllCustomersAsync());
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<CustomerDto>> GetCustomerByEmail(string email) //csak akkor ugrik ide, ha a paraméter illeszkedik (string típusú)
    {
        CustomerDto? customer = await _service.GetCustomerByEmailAsync(email);
        if (customer is null)
        {
            return NotFound();
        }

        return Ok(customer);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customerDto)
    {
        ServiceResult<CustomerDto>? newCustomerResult = await _service.CreateCustomerAsync(customerDto);
        if (!newCustomerResult.Success)
        {
            return newCustomerResult.ServiceErrorCode switch
            {
                ServiceErrorCode.AlreadyExists => Conflict(newCustomerResult),
                ServiceErrorCode.ValidationError => BadRequest(newCustomerResult),
                ServiceErrorCode.DatabaseError => StatusCode(500, newCustomerResult),
                _ => StatusCode(500, newCustomerResult)
            };
        }
        return Ok(newCustomerResult);
    }

    [HttpPut("{email}")]
    public async Task<IActionResult> UpdateCustomer(string email, [FromBody] CustomerDto customerDto)
    {
        CustomerDto? customer = await _service.UpdateCustomerAsync(email, customerDto);
        if (customer is null)
        {
            return BadRequest();
        }

        return Ok(customer);
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> Delete(string email)
    {
        bool success = await _service.DeleteCustomerAsync(email);
        if (success)
        {
            return Ok();
        }

        return NotFound();
    }
}