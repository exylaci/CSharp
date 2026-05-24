namespace Mobile.Models;

public class CustomerModel //frontendben használt modell (kisebb projektnél elegendő a DTO is)
{
    public string Email { get; set; } = string.Empty; //kezdő érték, hogy ne kelljen a null-lal foglalkozni
}