namespace ASPdotNETticketAPI.Configuration;

public class JwtSettings
{
    public const string SectionName = "JwtSettings"; //Az appsettings ezen név alatt tárolja az adatokat
    public string Issuer { get; set; } = string.Empty; //A token kibocsájtója
    public string Audience { get; set; } = string.Empty; //A token címzettje
    public string Key { get; set; } = string.Empty; //Titkos kulcs a token aláírásához
    public int ExpirationMinutes { get; set; } = 120; //A token érvényességi ideje
}