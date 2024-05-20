using Customer.Domain.DTO;
using Customer.Domain.Validations;
using Customer.Domain.Validations.Customer;
using FluentValidation.TestHelper;

namespace Customer.API.UnitTests.Validations;

public class CreateCustomerCommandValidatorTests
{
    private readonly CreateCustomerCommandValidator _validator;

    public CreateCustomerCommandValidatorTests()
    {
        _validator = new CreateCustomerCommandValidator();
    }

    [Fact]
    public void CreateCustomerCommandValidator_ShouldHaveError()
    {
        var request = new CreateCustomerRequest();

        var result = _validator.TestValidate(request);

        result.ShouldHaveValidationErrorFor(request => request.Name).WithErrorMessage(ValidationErrors.ECC001.Message);
    }
}
