using AutoMapper;
using Customer.API.UnitTests.Helpers;
using Customer.Application.Feature.Customer.Commands;
using Customer.Application.Mapping;
using Customer.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Customer.API.UnitTests.Business.Command;

public class UpdateCustomerCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<ILogger<UpdateCustomerCommandHandler>> _logger;

    public UpdateCustomerCommandHandlerTests()
    {
        _unitOfWork = UnitOfWorkMock.GetUnitOfWork();
        
        var mapperCofig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperCofig.CreateMapper();
        _logger = new Mock<ILogger<UpdateCustomerCommandHandler>>();

        CustomerMock.AddDataCustomerRepository(_unitOfWork.Object.AppDbContext);
    }

    [Fact]
    public async Task UpdateCustomer_Handle_ReturnSucccessAsync()
    {
        var customerCommand = new UpdateCustomerCommand(CustomerMock.UpdateCustomerRequestMock());

        var handler = new UpdateCustomerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
        var result = await handler.Handle(customerCommand, CancellationToken.None);

        result.ShouldBeOfType<bool>();
    }
}
