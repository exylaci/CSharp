using System.Text.Json;

namespace CRUDticketConsole;

internal static class Program
{
    const string Url = "https://localhost:7210/";

    static async Task Main()
    {
        HttpClient client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        });

        do
        {
            switch (Menu())
            {
                case '0': return;
                case '1': GetAllTicket(client); break;
                case '2': GetAllCategory(client); break;
                case '3': GetOneTicket(client); break;
                case '4': break;
                case '5': break;
                case '6': break;
                case '7': break;
                case '8': ManualRequest(client); break;
            }
        } while (true);
    }

    public static char Menu()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("1: Az összes Ticket lekérdezése");
        Console.WriteLine("2: Az összes Category lekérdezése");
        Console.WriteLine("3: Egy Ticket lekérdezése ID alapján");
        Console.WriteLine("4: Egy Category lekérdezése ID alapján");
        Console.WriteLine("5: Egy Ticket módosítása");
        Console.WriteLine("6: Egy Ticket státuszának módosítása");
        Console.WriteLine("7: Egy Ticket törlése");
        Console.WriteLine("8: Saját kézi lekérdezés");
        Console.WriteLine("0: Kilépés");
        Console.WriteLine("----------------------------------------------");
        char choice;
        do
        {
            choice = Console.ReadKey(true).KeyChar;
        } while (choice < '0' || choice > '8');

        return choice;
    }

    private async static void GetAllTicket(HttpClient client)
    {
        HttpResponseMessage response = await client.GetAsync(Url + "api/Tickets");
        Console.WriteLine($"1: Tickets \tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        string responseBody = await response.Content.ReadAsStringAsync();
        JsonDocument tickets = JsonDocument.Parse(responseBody);
        foreach (JsonElement ticket in tickets.RootElement.EnumerateArray())
        {
            foreach (JsonProperty tag in ticket.EnumerateObject())
            {
                Console.WriteLine($"{tag.Name,15} - {tag.Value}");
            }

            Console.WriteLine("----------------------------------------------");
        }
    }

    private async static void GetAllCategory(HttpClient client)
    {
        HttpResponseMessage response = await client.GetAsync(Url + "api/Category");
        Console.WriteLine($"2: Categories\tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        string responseBody = await response.Content.ReadAsStringAsync();
        JsonDocument categories = JsonDocument.Parse(responseBody);
        foreach (JsonElement category in categories.RootElement.EnumerateArray())
        {
            foreach (JsonProperty tag in category.EnumerateObject())
            {
                Console.WriteLine($"{tag.Name,15} - {tag.Value}");
            }

            Console.WriteLine("----------------------------------------------");
        }
    }

    private async static void GetOneTicket(HttpClient client)
    {
        Console.Write("3: A lekérdezéshez add meg a Ticket ID-t: ");
        string id = Console.ReadLine();
        HttpResponseMessage response = await client.GetAsync(Url + "api/Tickets/" + id);
        Console.WriteLine($"A(z) {id} azonosítójú Ticket \tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        string responseBody = await response.Content.ReadAsStringAsync();
        JsonDocument tickets = JsonDocument.Parse(responseBody);
        JsonElement ticket = tickets.RootElement;
        if (ticket.ValueKind == JsonValueKind.Array)
        {
            Console.WriteLine("Nem adtál meg ID-t ezért nem egyetlen Ticket adata jött a válaszban:\n" + responseBody);
            return;
        }

        foreach (JsonProperty tag in ticket.EnumerateObject())
        {
            Console.WriteLine($"{tag.Name,15} - {tag.Value}");
        }

        Console.WriteLine("----------------------------------------------");
    }

    private async static void ManualRequest(HttpClient client)
    {
        Console.Write("8: Írd be a lekérdezést: ");
        string request = Console.ReadLine();
        HttpResponseMessage response = await client.GetAsync(request);
        Console.WriteLine($" A lekérdezés eredménye \tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}