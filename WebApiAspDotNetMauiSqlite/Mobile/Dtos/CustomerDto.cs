namespace Mobile.Dtos;

public class CustomerDto //Data Transfer Object. Ezeket az adatokat küldi-fogadja a backendnek/-től
{
    public string Email { get; set; } = string.Empty; //kezdő érték, hogy ne kelljen a null-lal foglalkozni
}