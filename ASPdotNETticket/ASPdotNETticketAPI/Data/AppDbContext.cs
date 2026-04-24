using ASPdotNETticketAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETticketAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<AppUser> Users => Set<AppUser>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Szükség van az objektum szintű validációra. (Függetlenűl attól, mit tudna maga az adatbázis is validálni.)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .Property(c => c.Name).IsRequired()
            .HasMaxLength(100); //kötelező mező, max 100 karakter hosszú (Az SQL parancsok leképezése ide a C# objektumunkra is.)
        modelBuilder.Entity<Category>()
            .Property(c => c.Description).IsRequired()
            .HasMaxLength(500);
        modelBuilder.Entity<Ticket>()
            .Property(t => t.Title).IsRequired()
            .HasMaxLength(200);
        modelBuilder.Entity<Ticket>()
            .Property(t => t.Description)
            .HasMaxLength(500);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Category)
            .WithMany(c => c.Tickets)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); //1db Category-ája van, de egy Category-ának lehet több Ticket-e is. Az idegen kulcs a CategoryID. Törlésre a megkötés: Cascade, Restrict="Nem törlőlhető, amíg van külső függősége."
        
        modelBuilder.Entity<AppUser>()
            .HasIndex(u => u.Email)
            .IsUnique();
        modelBuilder.Entity<AppUser>()
            .Property(u => u.FullName)
            .IsRequired()
            .HasMaxLength(100);
        modelBuilder.Entity<AppUser>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);
        modelBuilder.Entity<AppUser>()
            .Property(u => u.PasswordHash)
            .IsRequired();
        modelBuilder.Entity<AppUser>()
            .Property(u => u.Role)
            .IsRequired()
            .HasMaxLength(30);
    }
}