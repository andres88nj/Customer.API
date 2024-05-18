using Microsoft.Extensions.Logging;
using Customers = Customer.Domain.Models.Customer;

namespace Customer.Infrastructure;

public class AppDbContextSeed
{
    public static async Task SeedAsync(AppDbContext context, ILogger<AppDbContextSeed> logger)
    {
        if (!context.Customers!.Any())
        {
            context.Customers!.AddRange(GetPreconfiguredStreamer());
            await context.SaveChangesAsync();

            logger.LogInformation("New records created {context}", typeof(AppDbContextSeed).Name);

            if(context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<Customers> GetPreconfiguredStreamer()
    {
        return new List<Customers>
        {
                new Customers {Name = "Jack Sparrow", DNI = "123456", Address = "Sea", Phone = "+15458", Mobile = "+15888", Email = "test@test.com", City = "Test", State = "TX" }
        };

    }
}
