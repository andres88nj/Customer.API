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
            new Customers { Name = "Peter Jhonson", DNI = "123456", Address = "Sea", Phone = "15458", Mobile = "15888", Email = "test1@test.com", City = "Miami", State = "Florida", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Jhon Strauss", DNI = "345345", Address = "Test", Phone = "4534", Mobile = "87654", Email = "test2@test.com", City = "Orlando", State = "Florida", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Tony Diaz", DNI = "567567", Address = "ABC", Phone = "7654", Mobile = "3456", Email = "test3@test.com", City = "California", State = "Los Angeles", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Carl Jackson", DNI = "24356", Address = "Home", Phone = "21231", Mobile = "23856", Email = "test4@test.com", City = "California", State = "Chicago", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Jack Obama", DNI = "9876", Address = "Test 3", Phone = "547567", Mobile = "9765432", Email = "test5@test.com", City = "California", State = "San Francisco", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Homer Asus", DNI = "645345", Address = "Test 4", Phone = "23435", Mobile = "32856", Email = "test6@test.com", City = "New York", State = "New York", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },

        };

    }
}
