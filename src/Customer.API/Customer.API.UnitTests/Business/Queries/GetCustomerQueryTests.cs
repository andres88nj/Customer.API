using AutoMapper;
using Customer.API.UnitTests.Helpers;
using Customer.Application.Feature.Customer.Queries;
using Customer.Application.Mapping;
using Customer.Domain.DTO;
using Customer.Infrastructure.Repositories;
using Moq;
using Shouldly;

namespace Customer.API.UnitTests.Business.Queries;

public class GetCustomerQueryTests
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;

    public GetCustomerQueryTests()
    {
        _unitOfWork = UnitOfWorkMock.GetUnitOfWork();
        var mapperCofig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });
        _mapper = mapperCofig.CreateMapper();

        CustomerMock.AddDataCustomerRepository(_unitOfWork.Object.AppDbContext);
    }

    [Fact]
    public async Task GetCustomersQuery()
    {
        var handler = new GetCustomerQueryHandler(_unitOfWork.Object, _mapper);
        var request = new GetCustomerQuery(Guid.Parse("ab5ebb99-fe45-4da1-83e7-abdab5d6985f"));

        var result = await handler.Handle(request, CancellationToken.None);

        result.ShouldBeOfType<GetCustomerResponse>();
    }
}
