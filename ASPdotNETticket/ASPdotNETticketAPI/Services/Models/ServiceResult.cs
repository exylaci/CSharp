namespace ASPdotNETticketAPI.Services.Models;

public class ServiceResult //Csak arra használjuk, hogy sikerűlt-e a művelet, vagy sem. Nem konkrét adat visszaadására. Pl DELETE
{
    public bool IsSuccess { get; private init; } //private init: csak osztályon belül és csak egyszer állíthatók be az értékek
    public bool IsNotFound { get; private init; }
    public string? Message { get; private init; }
    public Dictionary<string, string[]> Errors { get; private init; } = new Dictionary<string, string[]>();

    public static ServiceResult Success() //Factory model, sikeresség esetén ezt adja vissza
    {
        return new ServiceResult { IsSuccess = true };
    }

    public static ServiceResult NotFound(string message) //Factory model, sikertelenség esetén ezt adja vissza
    {
        return new ServiceResult { IsSuccess = false, Message = message };
    }

    public static ServiceResult Validation(string key, string message)
    {
        return new ServiceResult { Errors = new Dictionary<string, string[]> { [key] = [message] } };
    }

    public static ServiceResult Validation(Dictionary<string, string[]> errors)
    {
        return new ServiceResult { Errors = errors };
    }
}