using Customer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Customers = Customer.Domain.Models.Customer;

namespace Customer.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Customers> Customers { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<State> States { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Customers>()
            .HasKey(x => x.Id);

        builder.Entity<State>()
            .HasMany(e => e.Cities)
            .WithOne(e => e.State)
            .HasForeignKey(e => e.StateId)
            .HasPrincipalKey(e => e.Id);

        builder.Entity<City>()
            //.HasKey(x => x.Id);
            .HasOne(e => e.Customer)
            .WithOne(e => e.City)
            .HasForeignKey<Customers>(e => e.CityId)
            .IsRequired();
    }
}

public static class CustomerDbContextFactory
{
    public static AppDbContext Create(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        var context = new AppDbContext(optionsBuilder.Options);
        context.Database.EnsureCreated();

        return context;
    }
}