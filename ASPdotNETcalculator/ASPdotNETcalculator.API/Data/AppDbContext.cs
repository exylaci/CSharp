using ASPdotNETcalculator.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPdotNETcalculator.API.Data;

public class AppDbContext : DbContext
{
    public DbSet<Memory> Memory => Set<Memory>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Memory>(record =>
        {
            record.ToTable("Memory");
            record.HasKey(column => column.Id);
            record.Property(column => column.Value)
                .HasColumnType("REAL") // double az SQlite-ban
                .IsRequired();
        });

    }
}