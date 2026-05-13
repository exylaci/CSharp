namespace ASPdotNETcalculator.API.Services.Models;

public class ServiceResult
{
    public bool IsSuccess { get; private init; } //private init: csak osztályon belül és csak egyszer állíthatók be az értékek
    public bool IsNotFound { get; private init; }
    public string? Message { get; private init; }
    public Dictionary<string, string[]> Errors { get; private init; } = new Dictionary<string, string[]>();

    public static ServiceResult Success()
    {
        return new ServiceResult { IsSuccess = true };
    } //Factory model, sikeresség esetén ezt adja vissza

    public static ServiceResult NotFound(string message)
    {
        return new ServiceResult { IsSuccess = false, Message = message };
    } //Factory model, sikertelenség esetén ezt adja vissza

    public static ServiceResult Validation(string key, string message)
    {
        return new ServiceResult { Errors = new Dictionary<string, string[]> { [key] = [message] } };
    }

    public static ServiceResult Validation(Dictionary<string, string[]> errors)
    {
        return new ServiceResult { Errors = errors };
    }
}

public class ServiceResult<T>
{
    public bool IsSuccess { get; private init; }
    public bool IsNotFound { get; private init; }
    public string? Message { get; private init; }
    public T? Data { get; private init; } //Az adatnak
    public Dictionary<string, string[]> Errors { get; private init; } = new Dictionary<string, string[]>();

    public static ServiceResult<T> Success(T data)
    {
        return new ServiceResult<T> { IsSuccess = true, Data = data };
    } //Csak sikeresség esetén van adat.

    public static ServiceResult<T> NotFound(string message)
    {
        return new ServiceResult<T> { IsSuccess = false, Message = message };
    }

    public static ServiceResult<T> Validation(string key, string message)
    {
        return new ServiceResult<T> { Errors = new Dictionary<string, string[]> { [key] = [message] } };
    }

    public static ServiceResult<T> Validation(Dictionary<string, string[]> errors)
    {
        return new ServiceResult<T> { Errors = errors };
    }
}