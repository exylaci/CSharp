using ASPdotNETticketAPI.Constants;
using ASPdotNETticketAPI.Entities;
using ASPdotNETticketAPI.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Data;

public static class SeedData
{
    //Csak azért csináljuk ezt az osztályt, hogy legyen beletöltve kezdő adat az adatbázisba, szinkronban a programunkkal. Ezt egyébként docker migrációs scripttel csinálják meg, sohasem magában a program kódban!


    public static void Initialize(AppDbContext context) //Az AppDbContext-en keresztűl végezzük el az adatbázishoz hozzáadaás műveleteket. 
    {
        SeedCategories(context);
        SeedUsers(context);
        SeedTickets(context);
        SeedComments(context);
    }


    public static async Task InitializeAsync(AppDbContext context, CancellationToken cancellationToken = default) //Kell belőle egy async is, mert mi van, ha fut belőle mégegy példány? Akkor aszinkron kell megközelíeni a dolgot. Akkor ennek az init függvénynek már nem is kell futnia. Ehhez kell egy cancellation token, ami jelzni, hogy folyik-e kategóriával, jeggyel kapcsolatos művelet. 
    {
        await SeedCategoriesAsync(context, cancellationToken);
        await SeedUsersAsync(context, cancellationToken);
        await SeedTicketsAsync(context, cancellationToken);
        await SeedCommentsAsync(context, cancellationToken);
    }

    private static void SeedComments(AppDbContext context)
    {
        if (context.TicketComments.Any()) //Ha már van kezdő adatunk ne adja hozzá még egyszer.
        {
            return;
        }

        int adminId = context.Users.First(u => u.Email == "admin@pelda.hu").Id;
        int agentId = context.Users.First(u => u.Email == "agent@pelda.hu").Id;
        int userId = context.Users.First(u => u.Email == "user@pelda.hu").Id;

        int loginTicketId = context.Tickets.First(t => t.Title == "Nem tud bejelentkezni a felhasználó").Id;
        int darkModeTicketId = context.Tickets.First(t => t.Title == "Dark mód igénylése").Id;

        context.TicketComments.AddRange(
            new TicketComment
            {
                TicketId = loginTicketId,
                UserId = userId,
                Content = "1. A hibát ma reggel tapasztaltam, mindig visszadob a login oldalra.",
                CreatedAt = DateTime.Now.AddHours(-4)
            },
            new TicketComment
            {
                TicketId = loginTicketId,
                UserId = agentId,
                Content = "2. Átnéztem a logokat, és úgy tűnik, hogy a section környékén van a hiba.",
                CreatedAt = DateTime.Now.AddHours(-3)
            },
            new TicketComment
            {
                TicketId = darkModeTicketId,
                UserId = adminId,
                Content = "3. Az igény rögzítve, ez majd külön feature lesz. ",
                CreatedAt = DateTime.Now.AddHours(-2)
            });
        context.SaveChanges();
    }

    private static async Task SeedCommentsAsync(AppDbContext context, CancellationToken cancellationToken)
    {
        if (await context.TicketComments.AnyAsync())
        {
            return;
        }

        int adminId = (await context.Users.FirstAsync(u => u.Email == "admin@pelda.hu")).Id;
        int agentId = (await context.Users.FirstAsync(u => u.Email == "agent@pelda.hu")).Id;
        int userId = (await context.Users.FirstAsync(u => u.Email == "user@pelda.hu")).Id;

        int loginTicketId = (await context.Tickets.FirstAsync(t => t.Title == "Nem tud bejelentkezni a felhasználó")).Id;
        int darkModeTicketId =(await context.Tickets.FirstAsync(t => t.Title == "Dark mód igénylése")).Id;
        context.TicketComments.AddRange(
            new TicketComment
            {
                TicketId = loginTicketId,
                UserId = userId,
                Content = "1. A hibát ma reggel tapasztaltam, mindig visszadob a login oldalra.",
                CreatedAt = DateTime.Now.AddHours(-4)
            },
            new TicketComment
            {
                TicketId = loginTicketId,
                UserId = agentId,
                Content = "2. Átnéztem a logokat, és úgy tűnik, hogy a section környékén van a hiba.",
                CreatedAt = DateTime.Now.AddHours(-3)
            },
            new TicketComment
            {
                TicketId = darkModeTicketId,
                UserId = adminId,
                Content = "3. Az igény rögzítve, ez majd külön feature lesz. ",
                CreatedAt = DateTime.Now.AddHours(-2)
            });
        await context.SaveChangesAsync(cancellationToken);
    }

    private static void SeedCategories(AppDbContext context)
    {
        if (context.Categories.Any())
        {
            return;
        }

        context.Categories.AddRange(
            new Category
            {
                Name = "Bug",
                Description = "Hibajegyek a rendszer működésével kapcsolatban"
            },
            new Category
            {
                Name = "Feature Request",
                Description = "Új funkcióra vonatkozó igények"
            },
            new Category
            {
                Name = "Support",
                Description = "Általános támogatási és használati kérdések"
            });
        context.SaveChanges();
    }


    private static async Task SeedCategoriesAsync(AppDbContext context, CancellationToken cancellationToken)
    {
        if (await context.Categories.AnyAsync(cancellationToken))
        {
            return;
        }

        context.Categories.AddRange(
            new Category
            {
                Name = "Bug",
                Description = "Hibajegyek a rendszer működésével kapcsolatban"
            },
            new Category
            {
                Name = "Feature Request",
                Description = "Új funkcióra vonatkozó igények"
            },
            new Category
            {
                Name = "Support",
                Description = "Általános támogatási és használati kérdések"
            });
        context.SaveChanges();
    }

    private static void SeedTickets(AppDbContext context)
    {
        if (context.Tickets.Any())
        {
            return;
        }

        int bugCategoryId = context.Categories.First(c => c.Name == "Bug").Id; //Az egyes kategóriák ID-jainak lekérése, hogy hozzá tudjuk rendelni a jegyek minta adatokhoz
        int featureCategoryId = context.Categories.First(c => c.Name == "Feature Request").Id;
        int supportCategoryId = context.Categories.First(c => c.Name == "Support").Id;

        int adminId = context.Users.First(u => u.Email == "admin@pelda.hu").Id;
        int agentId = context.Users.First(u => u.Email == "agent@pelda.hu").Id;
        int userId = context.Users.First(u => u.Email == "user@pelda.hu").Id;


        context.Tickets.AddRange( //A minta jegy adat példányosítása és hozzádaása a data contexthez mehet egylépésben is.
            new Ticket
            {
                Title = "Nem tud bejelentkezni a felhasználó",
                Description = "A felhasználó helyes jeszóval sem tud bejelentkezni",
                Status = TicketStatus.Open,
                Priority = TicketPriority.High,
                CategoryId = bugCategoryId,
                CreatedAt = DateTime.Now.AddHours(-5),
                CreatedByUserId = userId,
                AssignedToUserId = null
            },
            new Ticket
            {
                Title = "Dark mód igénylése",
                Description = "A felhasználó dark módot szeretne kapni",
                Status = TicketStatus.Open,
                Priority = TicketPriority.Medium,
                CategoryId = featureCategoryId,
                CreatedAt = DateTime.Now.AddHours(-3),
                CreatedByUserId = userId,
                AssignedToUserId = agentId
            },
            new Ticket
            {
                Title = "Exportálás funkció magyarázata",
                Description = "A felhasználó segítséget kér, mert nem érti mi az az exportálás",
                Status = TicketStatus.InProgress,
                Priority = TicketPriority.Low,
                CategoryId = supportCategoryId,
                CreatedAt = DateTime.Now.AddHours(-1),
                CreatedByUserId = adminId,
                AssignedToUserId = agentId
            }
        );
        context.SaveChanges();
    }

    private static async Task SeedTicketsAsync(AppDbContext context, CancellationToken cancellationToken)
    {
        if (await context.Tickets.AnyAsync(cancellationToken))
        {
            return;
        }

        int bugCategoryId = context.Categories.First(c => c.Name == "Bug").Id; //Az egyes kategóriák ID-jainak lekérése, hogy hozzá tudjuk rendelni a jegyek minta adatokhoz
        int featureCategoryId = context.Categories.First(c => c.Name == "Feature Request").Id;
        int supportCategoryId = context.Categories.First(c => c.Name == "Support").Id;

        int adminId = context.Users.First(u => u.Email == "admin@pelda.hu").Id;
        int agentId = context.Users.First(u => u.Email == "agent@pelda.hu").Id;
        int userId = context.Users.First(u => u.Email == "user@pelda.hu").Id;

        context.Tickets.AddRange( //A minta jegy adat példányosítása és hozzádaása a data contexthez mehet egylépésben is.
            new Ticket
            {
                Title = "Nem tud bejelentkezni a felhasználó",
                Description = "A felhasználó helyes jeszóval sem tud bejelentkezni",
                Status = TicketStatus.Open,
                Priority = TicketPriority.High,
                CategoryId = bugCategoryId,
                CreatedAt = DateTime.Now.AddHours(-5),
                CreatedByUserId = userId,
                AssignedToUserId = null
            },
            new Ticket
            {
                Title = "Dark mód igénylése",
                Description = "A felhasználó dark módot szeretne kapni",
                Status = TicketStatus.Open,
                Priority = TicketPriority.Medium,
                CategoryId = featureCategoryId,
                CreatedAt = DateTime.Now.AddHours(-3),
                CreatedByUserId = userId,
                AssignedToUserId = agentId
            },
            new Ticket
            {
                Title = "Exportálás funkció magyarázata",
                Description = "A felhasználó segítséget kér, mert nem érti mi az az exportálás",
                Status = TicketStatus.InProgress,
                Priority = TicketPriority.Low,
                CategoryId = supportCategoryId,
                CreatedAt = DateTime.Now.AddHours(-1),
                CreatedByUserId = adminId,
                AssignedToUserId = agentId
            }
        );
        await context.SaveChangesAsync(cancellationToken);
    }

    private static void SeedUsers(AppDbContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        context.Users.AddRange(
            CreateSeedUser("Rendszergazda", "admin@pelda.hu", RoleNames.Admin, "Admin123!"),
            CreateSeedUser("Agent Smith", "agent@pelda.hu", RoleNames.Agent, "Agent123!"),
            CreateSeedUser("Teszt Elek", "user@pelda.hu", RoleNames.User, "User123!"));
        context.SaveChanges();
    }

    private static async Task SeedUsersAsync(AppDbContext context, CancellationToken cancellationToken)
    {
        if (await context.Users.AnyAsync(cancellationToken))
        {
            return;
        }

        context.Users.AddRange(
            CreateSeedUser("Rendszergazda", "admin@pelda.hu", RoleNames.Admin, "Admin123!"),
            CreateSeedUser("Agent Smith", "agent@pelda.hu", RoleNames.Agent, "Agent123!"),
            CreateSeedUser("Teszt Elek", "user@pelda.hu", RoleNames.User, "User123!"));
        await context.SaveChangesAsync(cancellationToken);
    }

    private static AppUser CreateSeedUser(string fullname, string email, string role, string password)
    {
        string normalizedEmail = email.Trim().ToLowerInvariant();

        AppUser user = new AppUser
        {
            FullName = fullname.Trim(),
            Email = normalizedEmail,
            Role = role,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
        PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, password);
        return user;
    }
}