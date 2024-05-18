using Customer.Domain.Models;
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
        var state = new State() { Id = Guid.NewGuid(), Name = "Florida", ZipCode = "FL", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };

        var city = new City() { Id = Guid.NewGuid(), Name = "Miami", State = state, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
        
        return new List<Customers>
        {
            new Customers {Name = "Jack Sparrow", DNI = "123456", Address = "Sea", Phone = "+15458", Mobile = "+15888", Email = "test@test.com", City = city, CityId = city.Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" }
        };

    }
}
