using Customer.Domain.Models;
using Microsoft.Extensions.Logging;
using Customers = Customer.Domain.Models.Customer;

namespace Customer.Infrastructure;

public class AppDbContextSeed
{
    public static async Task SeedAsync(AppDbContext context, ILogger<AppDbContextSeed> logger)
    {
        var state = GetPreconfiguredStates();
        var city = GetPreconfiguredCities(state);
        var customer = GetPreconfiguredCustomers(city);

        if (!context.States!.Any())
        {    
            context.States!.AddRange(state);
            await context.SaveChangesAsync();

            logger.LogInformation("New records created {context}", typeof(AppDbContextSeed).Name);
        }

        if (!context.Cities!.Any())
        {
            context.Cities!.AddRange(city);
            await context.SaveChangesAsync();

            logger.LogInformation("New records created {context}", typeof(AppDbContextSeed).Name);
        }

        if (!context.Customers!.Any())
        {
            context.Customers!.AddRange(customer);
            await context.SaveChangesAsync();

            logger.LogInformation("New records created {context}", typeof(AppDbContextSeed).Name);
        }
    }

    private static State[] GetPreconfiguredStates()
    {
        return
        [
            new State { Name = "Florida", ZipCode = "FL", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new State { Name = "California", ZipCode = "CA", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new State { Name = "New York", ZipCode = "NY", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" }
        ];
    }

    private static City[] GetPreconfiguredCities(State[] states)
    {
        City[] cities =
        [
            new City{ Name = "Miami", State = states[0], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new City{ Name = "Orlando", State = states[0], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new City{ Name = "Los Angeles", State = states[1], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new City{ Name = "San Francisco", State = states[1], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new City{ Name = "Chicago", State = states[1], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new City{ Name = "New York", State = states[2], CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" }
        ];

        return cities;
    }

    private static Customers[] GetPreconfiguredCustomers(City[] cities)
    {
        Customers[] customers =
        [
            new Customers { Name = "Peter Jhonson", DNI = "123456", Address = "Sea", Phone = "15458", Mobile = "15888", Email = "test1@test.com", City = cities[0], CityId = cities[0].Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Jhon Strauss", DNI = "345345", Address = "Test", Phone = "4534", Mobile = "87654", Email = "test2@test.com", City = cities[1], CityId = cities[1].Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Tony Diaz", DNI = "567567", Address = "ABC", Phone = "7654", Mobile = "3456", Email = "test3@test.com", City = cities[2], CityId = cities[2].Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Carl Jackson", DNI = "24356", Address = "Home", Phone = "21231", Mobile = "23856", Email = "test4@test.com", City = cities[3], CityId = cities[3].Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Jack Obama", DNI = "9876", Address = "Test 3", Phone = "547567", Mobile = "9765432", Email = "test5@test.com", City = cities[4], CityId = cities[4].Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },
            new Customers { Name = "Homer Asus", DNI = "645345", Address = "Test 4", Phone = "23435", Mobile = "32856", Email = "test6@test.com", City = cities[5], CityId = cities[5].Id, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CreatedBy = "Admin", UpdatedBy = "Admin" },

        ];
 
        return customers;
    }
}
