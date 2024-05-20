using AutoFixture;
using Customer.Domain.DTO;
using Customer.Infrastructure;
using Customers = Customer.Domain.Models.Customer;

namespace Customer.API.UnitTests.Helpers;

public class CustomerMock
{
    public static void AddDataCustomerRepository(AppDbContext streamerDbContextFake)
    {
        var id = Guid.Parse("ab5ebb99-fe45-4da1-83e7-abdab5d6985f");
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        var customers = fixture.CreateMany<Customers>().ToList();
            
        customers.Add(fixture.Build<Customers>()
            .With(x => x.Id, id)
            .Create());

        streamerDbContextFake.Customers!.AddRange(customers);
        streamerDbContextFake.SaveChanges();
    }

    public static CreateCustomerRequest CreateCustomerRequestMock()
    {
        return new CreateCustomerRequest()
        {
            DNI = "dni",
            Name = "name",
            Address = "address",
            Email = "email@test.com",
            Mobile = "123",
            Phone = "456",
            City = "city",
            State = "state"
        };
    }

    public static UpdateCustomerRequest UpdateCustomerRequestMock()
    {
        return new UpdateCustomerRequest()
        {
            Id = Guid.Parse("ab5ebb99-fe45-4da1-83e7-abdab5d6985f"),
            DNI = "dni",
            Name = "update",
            Address = "address",
            Email = "email@test.com",
            Mobile = "123",
            Phone = "456",
            City = "city",
            State = "state"
        };
    }
    
}
