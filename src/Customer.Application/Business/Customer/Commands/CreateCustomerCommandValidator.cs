using Customer.Application.Validations;
using Customer.Domain.DTO;
using FluentValidation;

namespace Customer.Domain.Validations.Customer;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(ValidationErrors.ECC001.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.ECC001.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.ECC001.Message);

        RuleFor(x => x.DNI)
            .NotNull()
            .WithMessage(ValidationErrors.ECC002.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.ECC002.Message)
            .MaximumLength(10)
            .WithMessage(ValidationErrors.ECC002.Message);

        RuleFor(x => x.Address)
            .NotNull()
            .WithMessage(ValidationErrors.ECC003.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.ECC003.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.ECC003.Message);

        RuleFor(x => x.Phone)
            .NotNull()
            .WithMessage(ValidationErrors.ECC004.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.ECC004.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.ECC004.Message)
            .Numeric()
            .WithMessage(ValidationErrors.ECC008.Message);

        RuleFor(x => x.Mobile)
            .NotNull()
            .WithMessage(ValidationErrors.ECC005.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.ECC005.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.ECC005.Message)
            .Numeric()
            .WithMessage(ValidationErrors.EUC009.Message);

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage(ValidationErrors.ECC006.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.ECC006.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.ECC006.Message);

        RuleFor(x => x.City)
            .NotNull()
            .WithMessage(ValidationErrors.ECC007.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.ECC007.Message);
    } 
}

