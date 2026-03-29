using System.Text;
using System.Text.Json;

namespace CRUDticketConsole;

internal static class Program
{
    const string Url = "https://localhost:7210/";

    static void Main()
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
                case '4': GetOneCategory(client); break;
                case '5': NewTicket(client); break;
                // case '6': ModyfyTicket(client); break;
                // case '7': ModyfyTicketStatus(client); break;
                case '8': DeleteTicket(client); break;
                case '9': ManualRequest(client); break;
            }
        } while (true);
    }

    public static char Menu()
    {
        Console.WriteLine("1: Az összes Ticket lekérdezése");
        Console.WriteLine("2: Az összes Category lekérdezése");
        Console.WriteLine("3: Egy Ticket lekérdezése ID alapján");
        Console.WriteLine("4: Egy Category lekérdezése ID alapján");
        Console.WriteLine("5: Új Ticket létrehozása");
        Console.WriteLine("6: Egy Ticket módosítása");
        Console.WriteLine("7: Egy Ticket státuszának módosítása");
        Console.WriteLine("8: Egy Ticket törlése");
        Console.WriteLine("9: Kézel megírt lekérdezés");
        Console.WriteLine("0: Kilépés");
        Console.WriteLine("----------------------------------------------");
        char choice;
        do
        {
            choice = Console.ReadKey(true).KeyChar;
        } while (choice < '0' || choice > '8');

        return choice;
    }

    private static void GetAllTicket(HttpClient client)
    {
        HttpResponseMessage response = client.GetAsync(Url + "api/Tickets").Result;
        Console.WriteLine($"1: Tickets \tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        string responseBody = response.Content.ReadAsStringAsync().Result;
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

    private static void GetAllCategory(HttpClient client)
    {
        HttpResponseMessage response = client.GetAsync(Url + "api/Categories").Result;
        Console.WriteLine($"2: Categories\tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        if (!response.IsSuccessStatusCode)
        {
            return;
        }

        string responseBody = response.Content.ReadAsStringAsync().Result;
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

    private static void GetOneTicket(HttpClient client, string id = "")
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            Console.Write("3: A lekérdezéshez add meg a Ticket ID-t: ");
            id = Console.ReadLine() ?? string.Empty;
        }

        HttpResponseMessage response = client.GetAsync(Url + "api/Tickets/" + id).Result;
        Console.WriteLine($"A(z) ID={id} azonosítójú Ticket lekérdezése \tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Nincs ilyen Ticket!!!\n----------------------------------------------");
            return;
        }

        string responseBody = response.Content.ReadAsStringAsync().Result;
        JsonElement ticket = JsonDocument.Parse(responseBody).RootElement;
        if (ticket.ValueKind == JsonValueKind.Array)
        {
            Console.WriteLine("Nem adtál meg ID-t ezért nem egyetlen Ticket adata jött a válaszban:\n" + responseBody);
            Console.WriteLine("----------------------------------------------");
            return;
        }

        foreach (JsonProperty tag in ticket.EnumerateObject())
        {
            Console.WriteLine($"{tag.Name,15} - {tag.Value}");
        }

        Console.WriteLine("----------------------------------------------");
    }

    private static void GetOneCategory(HttpClient client)
    {
        Console.Write("4: A lekérdezéshez add meg a Category ID-t: ");
        string id = Console.ReadLine() ?? string.Empty;
        HttpResponseMessage response = client.GetAsync(Url + "api/Categories/" + id).Result;
        Console.WriteLine($"A(z) {id} azonosítójú Category \tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Nincs ilyen Category!!!\n----------------------------------------------");
            return;
        }

        string responseBody = response.Content.ReadAsStringAsync().Result;
        JsonElement category = JsonDocument.Parse(responseBody).RootElement;
        if (category.ValueKind == JsonValueKind.Array)
        {
            Console.WriteLine("Nem adtál meg ID-t ezért nem egyetlen Category adata jött a válaszban:\n" + responseBody);
            Console.WriteLine("----------------------------------------------");
            return;
        }

        Console.WriteLine("----------------------------------------------");
        foreach (JsonProperty tag in category.EnumerateObject())
        {
            Console.WriteLine($"{tag.Name,15} - {tag.Value}");
        }

        Console.WriteLine("----------------------------------------------");
    }

    private static void NewTicket(HttpClient client)
    {
        TicketDto ticket = new TicketDto();
        ticket.EditTicket();
        var content = new StringContent(JsonSerializer.Serialize(ticket), Encoding.UTF8, "application/json");
        var response = client.PostAsync(Url + "api/Tickets", content).Result;
        Console.WriteLine($"\n --> {response.StatusCode} \nEltárolt Ticket lekérdezésése:");
        GetOneTicket(client, ticket.Id.ToString());
    }

    private static void DeleteTicket(HttpClient client)
    {
        Console.Write("8: A törlendő Ticket ID-ja: ");
        string id = Console.ReadLine() ?? string.Empty;

        HttpResponseMessage response = client.DeleteAsync(Url + "api/Tickets/" + id).Result;
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine("Nem sikerűlt törölni!!!\n----------------------------------------------");
            return;
        }

        Console.WriteLine($"\n --> {response.StatusCode} \nTörlés ellenőrzése a Ticket lekérdezésével:");
        GetOneTicket(client, id);
    }

    private async static void ManualRequest(HttpClient client)
    {
        Console.Write("8: Írd be a kiküldendő lekérdezést: ");
        string request = Console.ReadLine();
        HttpResponseMessage response = await client.GetAsync(request);
        Console.WriteLine($" A lekérdezés eredménye \tStátusz kód: {(int)response.StatusCode}, {response.StatusCode}");
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
    }
}