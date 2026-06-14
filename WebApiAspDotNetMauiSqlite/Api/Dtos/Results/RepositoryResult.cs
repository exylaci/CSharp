namespace Api.Dtos.Results;

public class RepositoryResult<T> //Ezt kapja vissza a service réteg, ebbe csomagoljuk bele az adatot és az esetleges hibaüzenetet
{
    public bool Success { get; set; }
    public RepositoryErrorCode ErrorCode { get; set; }
    public string? ErrorMessage { get; set; }
    public T? Data { get; set; }
}