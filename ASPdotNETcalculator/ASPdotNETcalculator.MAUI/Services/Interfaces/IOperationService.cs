using ASPdotNETcalculator.MAUI.Dtos;

namespace ASPdotNETcalculator.MAUI.Services.Interfaces;

public interface IOperationService
{
    Task<Response> Addition(Question question);
    Task<Response> Substraction(Question question);
    Task<Response> Multiplication(Question question);
    Task<Response> Division(Question question);
    Task Store(Store store);
    Task<Response> Recall();
    Task MemoryClear();
}