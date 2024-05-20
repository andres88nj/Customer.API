using AutoMapper;
using Customer.API.UnitTests.Helpers;
using Customer.Application.Feature.Customer.Commands;
using Customer.Application.Mapping;
using Customer.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;

namespace Customer.API.UnitTests.Business.Command;

public class DeleteCustomerCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<ILogger<DeleteCustomerCommandHandler>> _logger;

    public DeleteCustomerCommandHandlerTests()
    {
        _unitOfWork = UnitOfWorkMock.GetUnitOfWork();
        
        var mapperCofig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperCofig.CreateMapper();
        _logger = new Mock<ILogger<DeleteCustomerCommandHandler>>();

        CustomerMock.AddDataCustomerRepository(_unitOfWork.Object.AppDbContext);
    }

    [Fact]
    public async Task DeleteCustomer_Handle_ReturnSucccessAsync()
    {
        var customerCommand = new DeleteCustomerCommand(Guid.Parse("ab5ebb99-fe45-4da1-83e7-abdab5d6985f"));

        var handler = new DeleteCustomerCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
        var result = await handler.Handle(customerCommand, CancellationToken.None);

        result.ShouldBeOfType<bool>();
    }
}
