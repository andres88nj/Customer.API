using Customer.Infrastructure;
using Customer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Customer.API.UnitTests.Helpers;

public static class UnitOfWorkMock
{
    public static Mock<UnitOfWork> GetUnitOfWork()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseInMemoryDatabase(databaseName: $"AppDbContext-{Guid.NewGuid()}")
           .Options;

        var streamerDbContextFake = new AppDbContext(options);

        streamerDbContextFake.Database.EnsureDeleted();
        var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);

        return mockUnitOfWork;
    }
}
