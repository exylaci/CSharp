namespace Api.Dtos.Results;

public class ServiceResult<T> //Ezt kapja vissza a frontend, ebbe csomagoljuk bele az adatot és az esetleges hibaüzenetet
{
    public bool Success { get; set; } //True, ha nincs hiba
    public ServiceErrorCode ServiceErrorCode { get; set; } //program logikában használt hibakód
    public string? ErrorMessage { get; set; } //Felhasználónak kiírt üzenet
    public T? Data { get; set; } //A hasznos adat
}