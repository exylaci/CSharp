using System.Text.Json.Serialization;

namespace Mobile.Dtos.Errors;

public class ValidationProblemDetailsDto //A frontendtől jövő JSON formátumú ValidationProblemDetails objektum hibaüzenet deszerializálásához
{
    [JsonPropertyName("errors")] //A teljes JSON-ből az "errors" tartalmának kinyeréséhez "errors":{"Email":["Hibás e-mail cím formátum"]}
    public Dictionary<string, string[]>? Errors { get; set; }
}