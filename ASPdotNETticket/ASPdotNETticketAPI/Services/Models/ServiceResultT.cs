namespace ASPdotNETticketAPI.Services.Models;

public class ServiceResult<T> //Amikor van visszaadott adat is, GetById, Create, stb.
    //Nem konkrét http válaszokat gyárt, de a kontroller el tudja dönteni, hogy milyen státuszkód legyen a válasz
{
    public bool IsSuccess { get; private init; }
    public bool IsNotFound { get; private init; }
    public string? Message { get; private init; }
    public T? Data { get; private init; } //Az adatnak
    public Dictionary<string, string[]> Errors { get; private init; } = new Dictionary<string, string[]>();

    public static ServiceResult<T> Success(T data) //Csak sikeresség esetén van adat.
    {
        return new ServiceResult<T> { IsSuccess = true, Data = data };
    }

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