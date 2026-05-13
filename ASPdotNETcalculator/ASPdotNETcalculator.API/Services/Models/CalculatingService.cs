using ASPdotNETcalculator.API.Data;
using ASPdotNETcalculator.API.Dtos;
using ASPdotNETcalculator.API.Entities;
using ASPdotNETcalculator.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETcalculator.API.Services.Models;

public class CalculatingService : ICalculatingService
{
    private readonly AppDbContext _dbContext;

    public CalculatingService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResult<ResultDto>> AdditionAsync(CalculationRequestDto request)
    {
        ResultDto dto = new ResultDto();
        try
        {
            dto.Result = request.A + request.B;
            return ServiceResult<ResultDto>.Success(dto);
        }
        catch (Exception e)
        {
            dto.ErrorMessage = e.Message;
            return ServiceResult<ResultDto>.Validation("Nem tudom kiszámolni!", e.Message);
        }
    }

    public async Task<ServiceResult<ResultDto>> SubstractionAsync(CalculationRequestDto request)
    {
        ResultDto dto = new ResultDto();
        try
        {
            dto.Result = request.A - request.B;
            return ServiceResult<ResultDto>.Success(dto);
        }
        catch (Exception e)
        {
            dto.ErrorMessage = e.Message;
            return ServiceResult<ResultDto>.Validation("Nem tudom kiszámolni!", e.Message);
        }
    }

    public async Task<ServiceResult<ResultDto>> MultiplicationAsync(CalculationRequestDto request)
    {
        ResultDto dto = new ResultDto();
        try
        {
            dto.Result = request.A * request.B;
            return ServiceResult<ResultDto>.Success(dto);
        }
        catch (Exception e)
        {
            dto.ErrorMessage = e.Message;
            return ServiceResult<ResultDto>.Validation("Nem tudom kiszámolni!", e.Message);
        }
    }

    public async Task<ServiceResult<ResultDto>> DivisionAsync(CalculationRequestDto request)
    {
        if (request.B == 0)
        {
            return ServiceResult<ResultDto>.Validation("B", "Nullával nem lehet osztani!");
        }

        ResultDto dto = new ResultDto
        {
            Result = request.A / request.B
        };
        return ServiceResult<ResultDto>.Success(dto);
    }

    public async Task<ServiceResult> StoreAsync(StoreRequestDto request)
    {
        Memory? stored = await _dbContext.Memory.FirstOrDefaultAsync();
        if (stored is null)
        {
            stored = new Memory { Value = request.A };
            await _dbContext.Memory.AddAsync(stored);
        }
        else
        {
            stored.Value = request.A;
        }

        await _dbContext.SaveChangesAsync();
        return ServiceResult.Success();
    }

    public async Task<ServiceResult<ResultDto>> RecallAsync()
    {
        Memory? stored = await _dbContext.Memory.FirstOrDefaultAsync();
        if (stored is null)
        {
            return ServiceResult<ResultDto>.NotFound("Nincs a memóriában eltárolva semmi.");
        }

        ResultDto dto = new ResultDto
        {
            Result = stored.Value
        };
        return ServiceResult<ResultDto>.Success(dto);
    }


    public async Task MemoryClearAsync()
    {
        Memory? stored = await _dbContext.Memory.FirstOrDefaultAsync();
        if (stored is null)
        {
            return;
        }

        _dbContext.Memory.Remove(stored);
        await _dbContext.SaveChangesAsync();
    }
}