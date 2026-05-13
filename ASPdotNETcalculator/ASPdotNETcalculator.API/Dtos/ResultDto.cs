namespace ASPdotNETcalculator.API.Dtos;

public class ResultDto
{
    public double Result { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}