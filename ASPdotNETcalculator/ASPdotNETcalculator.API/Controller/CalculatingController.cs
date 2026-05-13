using ASPdotNETcalculator.API.Dtos;
using ASPdotNETcalculator.API.Services.Interfaces;
using ASPdotNETcalculator.API.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASPdotNETcalculator.API.Controller;

[ApiController]
[Route("calculator")]
public class CalculatingController : ControllerBase
{
    private readonly ICalculatingService _calculatingService;

    public CalculatingController(ICalculatingService calculatingService)
    {
        _calculatingService = calculatingService;
    }

    [HttpGet("add")]
    public async Task<ActionResult<ResultDto>> Addition([FromBody] CalculationRequestDto? dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }

        ServiceResult<ResultDto> result = await _calculatingService.AdditionAsync(dto);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result.Data);
    }

    [HttpGet("subs")]
    public async Task<ActionResult<ResultDto>> Substraction([FromBody] CalculationRequestDto? dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }

        ServiceResult<ResultDto> result = await _calculatingService.SubstractionAsync(dto);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result.Data);
    }

    [HttpGet("mult")]
    public async Task<ActionResult<ResultDto>> Multiplication([FromBody] CalculationRequestDto? dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }

        ServiceResult<ResultDto> result = await _calculatingService.MultiplicationAsync(dto);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result.Data);
    }

    [HttpGet("div")]
    public async Task<ActionResult<ResultDto>> Division([FromBody] CalculationRequestDto? dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }

        ServiceResult<ResultDto> result = await _calculatingService.DivisionAsync(dto);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result.Data);
    }

    [HttpPost("memorystore")]
    public async Task<ActionResult<ResultDto>> StoreMemory([FromBody] StoreRequestDto request)
    {
        ServiceResult result = await _calculatingService.StoreAsync(request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok();
    }

    [HttpGet("memoryread")]
    public async Task<ActionResult<ResultDto>> GetMemory()
    {
        ServiceResult<ResultDto> result = await _calculatingService.RecallAsync();
        if (!result.IsSuccess)
        {
            return NotFound(result);
        }

        return Ok(result.Data);
    }

    [HttpDelete("memoryclear")]
    public async Task<ActionResult<ResultDto>> ClearMemory()
    {
        await _calculatingService.MemoryClearAsync();
        return Ok();
    }
}