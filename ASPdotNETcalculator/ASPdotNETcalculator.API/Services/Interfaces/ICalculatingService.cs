using ASPdotNETcalculator.API.Dtos;
using ASPdotNETcalculator.API.Services.Models;

namespace ASPdotNETcalculator.API.Services.Interfaces;

public interface ICalculatingService
{
    Task<ServiceResult<ResultDto>> AdditionAsync(CalculationRequestDto request);
    Task<ServiceResult<ResultDto>> SubstractionAsync(CalculationRequestDto request);
    Task<ServiceResult<ResultDto>> MultiplicationAsync(CalculationRequestDto request);
    Task<ServiceResult<ResultDto>> DivisionAsync(CalculationRequestDto request);
    Task<ServiceResult> StoreAsync(StoreRequestDto request);
    Task<ServiceResult<ResultDto>> RecallAsync();
    Task MemoryClearAsync();
}