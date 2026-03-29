using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Data;

public static class SeedData
{
    //Csak azért csináljuk ezt az osztályt, hogy legyen beletöltve kezdő adat az adatbázisba, szinkronban a programunkkal. Ezt egyébként docker migrációs scripttel csinálják meg, sohasem magában a program kódban!
    public static void Initialize(AppDbContext context) //Az AppDbContext-en keresztűl végezzük el az adatbázishoz hozzáadaás műveleteket. 
    {
        if (!context.Categories.Any()) //Csak akkor teszünk bele adatot, ha még üres az adatbázis.
        {
            Category bugCategory = new Category //Pár db minta katekória adat példányosítása
            {
                Name = "Bug",
                Description = "Hibajegyek a rendszer működésével kapcsolatban"
            };
            Category featureCategory = new Category
            {
                Name = "Feature Request",
                Description = "Új funkcióra vonatkozó igények"
            };
            Category supportCategory = new Category
            {
                Name = "Support",
                Description = "Általános támogatási és használati kérdések"
            };
            context.Categories.AddRange(bugCategory, featureCategory, supportCategory); //E példányok hozzádaása a data contexthez
            context.SaveChanges(); //Adatbázis hozzászinkronizálása a data contextünkhöz
        }

        if (!context.Tickets.Any()) //Pár db minta jegy adat példányosítása, ha még nincs egy sem
        {
            int bugCategoryId = context.Categories.First(c => c.Name == "Bug").Id; //Az egyes kategóriák ID-jainak lekérése, hogy hozzá tudjuk rendelni a jegyek minta adatokhoz
            int featureCategoryId = context.Categories.First(c => c.Name == "Feature Request").Id;
            int supportCategoryId = context.Categories.First(c => c.Name == "Support").Id;

            context.Tickets.AddRange( //A minta jegy adat példányosítása és hozzádaása a data contexthez mehet egylépésben is.
                new Ticket
                {
                    Title = "Nem tud bejelentkezni a felhasználó",
                    Description = "A felhasználó helyes jeszóval sem tud bejelentkezni",
                    Status = TicketStatus.Open,
                    Priority = TicketPriority.Low,
                    CategoryId = bugCategoryId,
                    CreatedAt = DateTime.Now.AddHours(-5)
                },
                new Ticket
                {
                    Title = "Dark mód igénylése",
                    Description = "A felhasználó dark módot szeretne kapni",
                    Status = TicketStatus.Open,
                    Priority = TicketPriority.Medium,
                    CategoryId = featureCategoryId,
                    CreatedAt = DateTime.Now.AddHours(-3)
                },
                new Ticket
                {
                    Title = "Exportálás funkció magyarázata",
                    Description = "A felhasználó segítséget kér, mert nem érti mi az az exportálás",
                    Status = TicketStatus.InProgress,
                    Priority = TicketPriority.Low,
                    CategoryId = supportCategoryId,
                    CreatedAt = DateTime.Now.AddHours(-1)
                }
            );
            context.SaveChanges();
        }
    }

    public static async Task InitializeAsync(AppDbContext context, CancellationToken cancellationToken = default) //Kell belőle egy async is, mert mi van, ha fut belőle mégegy példány? Akkor aszinkron kell megközelíeni a dolgot. Akkor ennek az init függvénynek már nem is kell futnia. Ehhez kell egy cancellation token, ami jelzni, hogy folyik-e kategóriával, jeggyel kapcsolatos művelet. 
    {
        if (!await context.Categories.AnyAsync(cancellationToken)) //Csak akkor teszünk bele adatot, ha nem fut adatbázissal kapcsolatos művelet. (Az AnyAsync false-t ad ha fut művelet.)
        {
            Category bugCategory = new Category //Pár db minta katekória adat példányosítása
            {
                Name = "Bug",
                Description = "Hibajegyek a rendszer működésével kapcsolatban"
            };
            Category featureCategory = new Category
            {
                Name = "Feature Request",
                Description = "Új funkcióra vonatkozó igények"
            };
            Category supportCategory = new Category
            {
                Name = "Support",
                Description = "Általános támogatási és használati kérdések"
            };
            context.Categories.AddRange(bugCategory, featureCategory, supportCategory); //E példányok hozzádaása a data contexthez
            await context.SaveChangesAsync(cancellationToken); //Mivel az aszinkron művelet "nem tartja fel" a programot, Szinte minden adatbázis műveletnél kell az entitásokra vonatkozó cancellationtoken, ezzel jelezhetjük, hogy álljon le.
        }

        if (!await context.Tickets.AnyAsync(cancellationToken)) //Pár db minta jegy adat példányosítása, ha még nincs egy sem
        {
            int bugCategoryId = context.Categories.First(c => c.Name == "Bug").Id; //Az egyes kategóriák ID-jainak lekérése, hogy hozzá tudjuk rendelni a jegyek minta adatokhoz
            int featureCategoryId = context.Categories.First(c => c.Name == "Feature Request").Id;
            int supportCategoryId = context.Categories.First(c => c.Name == "Support").Id;

            context.Tickets.AddRange( //A minta jegy adat példányosítása és hozzádaása a data contexthez mehet egylépésben is.
                new Ticket
                {
                    Title = "Nem tud bejelentkezni a felhasználó",
                    Description = "A felhasználó helyes jeszóval sem tud bejelentkezni",
                    Status = TicketStatus.Open,
                    Priority = TicketPriority.Low,
                    CategoryId = bugCategoryId,
                    CreatedAt = DateTime.Now.AddHours(-5)
                },
                new Ticket
                {
                    Title = "Dark mód igénylése",
                    Description = "A felhasználó dark módot szeretne kapni",
                    Status = TicketStatus.Open,
                    Priority = TicketPriority.Medium,
                    CategoryId = featureCategoryId,
                    CreatedAt = DateTime.Now.AddHours(-3)
                },
                new Ticket
                {
                    Title = "Exportálás funkció magyarázata",
                    Description = "A felhasználó segítséget kér, mert nem érti mi az az exportálás",
                    Status = TicketStatus.InProgress,
                    Priority = TicketPriority.Low,
                    CategoryId = supportCategoryId,
                    CreatedAt = DateTime.Now.AddHours(-1)
                }
            );
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}