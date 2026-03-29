using System.Text.Json;

namespace CRUDticketConsole;

internal static class Program
{
    static async Task Main()
    {
        string url = "https://localhost:7210/";
        var client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        });

        var response = await client.GetAsync(url + "api/Tickets");

        Console.WriteLine($"{(int)response.StatusCode}\t{response.StatusCode}");

        string responseBody = await response.Content.ReadAsStringAsync();

        JsonDocument tickets = JsonDocument.Parse(responseBody);

        foreach (JsonElement ticket in tickets.RootElement.EnumerateArray())
        {
            foreach (JsonProperty tag in ticket.EnumerateObject())
            {
                Console.WriteLine($"{tag.Name,15}: {tag.Value}");
            }

            Console.WriteLine("----------------------------------------------");
        }

        Console.ReadKey();
    }
}