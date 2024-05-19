using Microsoft.EntityFrameworkCore;
using Customers = Customer.Domain.Models.Customer;

namespace Customer.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<Customers> Customers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Customers>()
            .HasKey(x => x.Id);
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