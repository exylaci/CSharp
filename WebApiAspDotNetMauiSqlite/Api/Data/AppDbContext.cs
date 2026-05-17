using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public class AppDbContext : DbContext
{
    public DbSet<CustomerEntity> Customers => Set<CustomerEntity>(); //Adattábla neve, benne lévő rekordokat leképező osztályunk

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) //Szükség van az objektum szintű validációra itt az API-ban, függetlenűl attól, mit tudna maga az adatbázis is validálni.
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CustomerEntity>()
            .HasKey(c => c.CustomerId); //Hogy tudja a Core ez az adattáblában a PrimaryKey

        modelBuilder.Entity<CustomerEntity>()
            .Property(e => e.Email) //Az adatbázisban az email mező
            .HasMaxLength(50) //max hossza 50 karakter
            .IsRequired(); //Kötelező mező (Nem lehet null, üres, stb.)
        modelBuilder.Entity<CustomerEntity>()
            .HasIndex(c => c.Email) //Indexelje le az adatbázis, hogy gyordabban tudjon keresni benne (Nem azonos az ID-vel!)
            .IsUnique(); //Egyéni kell legyen, nem lehet 2 ugyanojan érték az adattáblában.
    }
}