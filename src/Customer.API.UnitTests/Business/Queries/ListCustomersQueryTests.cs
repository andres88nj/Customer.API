using AutoMapper;
using Customer.API.UnitTests.Helpers;
using Customer.Application.Feature.Customer.Queries;
using Customer.Application.Mapping;
using Customer.Domain.DTO;
using Customer.Infrastructure.Repositories;
using Moq;
using Shouldly;

namespace Customer.API.UnitTests.Business.Queries;

public class ListCustomersQueryTests
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;

    public ListCustomersQueryTests()
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
    public async Task ListCustomersQuery()
    {
        var handler = new ListCustomersQueryHandler(_unitOfWork.Object, _mapper);
        var request = new ListCustomersQuery();

        var result = await handler.Handle(request, CancellationToken.None);

        result.ShouldBeOfType<List<GetCustomerResponse>>();
        result.Count().ShouldBe(result.Count());
    }
}
