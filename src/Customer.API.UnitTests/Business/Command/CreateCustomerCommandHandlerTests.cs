using AutoMapper;
using Customer.API.UnitTests.Helpers;
using Customer.Application.Feature.Customer.Commands;
using Customer.Application.Mapping;
using Customer.Domain.DTO;
using Customer.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Customer.API.UnitTests.Business.Command;

public class CreateCustomerCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<ILogger<CreateCustomerCommandHandler>> _logger;

    public CreateCustomerCommandHandlerTests()
    {
        _unitOfWork = UnitOfWorkMock.GetUnitOfWork();
        
        var mapperCofig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperCofig.CreateMapper();
        _logger = new Mock<ILogger<CreateCustomerCommandHandler>>();

        CustomerMock.AddDataCustomerRepository(_unitOfWork.Object.AppDbContext);
    }

    [Fact]
    public async Task CreateCustomer_Handle_ReturnSucccessAsync()
    {
        var customerCommand = new CreateCustomerCommand(CustomerMock.CreateCustomerRequestMock());

        var handler = new CreateCustomerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
        var result = await handler.Handle(customerCommand, CancellationToken.None);

        result.ShouldBeOfType<GetCustomerResponse>();
    }
}
