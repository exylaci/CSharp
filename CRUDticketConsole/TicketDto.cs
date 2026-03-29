using System.Globalization;
using System.Text;

namespace CRUDticketConsole;

public class TicketDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TicketStatus Status { get; set; } = TicketStatus.Open;
    public TicketPriority Priority { get; set; } = TicketPriority.Low;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;


    public TicketDto()
    {
    }

    public TicketDto(int id, string title, string description, TicketStatus status, TicketPriority priority, DateTime createdAt, int categoryId, string categoryName)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        CreatedAt = createdAt;
        CategoryId = categoryId;
        CategoryName = categoryName;
    }


    public void EditTicket()
    {
        Console.Write("           ID: ");
        Id = Int32.TryParse(Input(Id.ToString(), false), out int number) ? number : -1;

        Console.Write($"\n        Title: ");
        Title = Input(Title);

        Console.Write($"\n  Description: ");
        Description = Input(Description);

        Console.Write($"\n       Status: ");
        Status = Int32.TryParse(Input(((int)Status).ToString(), false), out number) ? (TicketStatus)number : TicketStatus.Open;
        Console.Write($" -> {Status}");

        Console.Write($"\n     Priority: ");
        Priority = Int32.TryParse(Input(((int)Priority).ToString(), false), out number) ? (TicketPriority)number : TicketPriority.Low;
        Console.Write($" -> {Priority}");

        Console.Write($"\n   Created at: ");
        try
        {
            CreatedAt = DateTime.ParseExact(
                Input(CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")),
                "yyyy-MM-ddTHH:mm:ss",
                CultureInfo.InvariantCulture
            );
        }
        catch (Exception e)
        {
            // ignored
        }

        Console.Write($" -> {CreatedAt:yyyy-MM-ddTHH:mm:ss.ff}");

        Console.Write($"\n  Category ID: ");
        CategoryId = Int32.TryParse(Input(CategoryId.ToString(), false), out number) ? number : -1;

        Console.Write($"\nCategory name: ");
        CategoryName = Input(CategoryName);
        Console.WriteLine();
    }

    private string Input(string text, bool alphanumeric = true)
    {
        StringBuilder sb = new StringBuilder(text);
        Console.Write(text);
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Backspace && sb.Length > 0)
            {
                sb.Length--;
                Console.Write("\b \b");
            }
            else if (!char.IsControl(key.KeyChar) && (alphanumeric || char.IsDigit(key.KeyChar)))
            {
                sb.Append(key.KeyChar);
                Console.Write(key.KeyChar);
            }
        } while (key.Key != ConsoleKey.Enter);

        return sb.ToString();
    }
}