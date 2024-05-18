using Customer.Application.Validations;
using Customer.Domain.DTO;
using FluentValidation;

namespace Customer.Domain.Validations.Customer;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerRequest>
{
    public UpdateCustomerCommandValidator()
    {
        //RuleFor(x => x.Id)
            

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(ValidationErrors.EUC001.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.EUC001.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.EUC001.Message);

        RuleFor(x => x.DNI)
            .NotNull()
            .WithMessage(ValidationErrors.EUC002.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.EUC002.Message)
            .MaximumLength(10)
            .WithMessage(ValidationErrors.EUC002.Message);

        RuleFor(x => x.Address)
            .NotNull()
            .WithMessage(ValidationErrors.EUC003.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.EUC003.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.EUC003.Message);

        RuleFor(x => x.Phone)
            .NotNull()
            .WithMessage(ValidationErrors.EUC004.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.EUC004.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.EUC004.Message)
            .Numeric()
            .WithMessage(ValidationErrors.EUC008.Message);

        RuleFor(x => x.Mobile)
            .NotNull()
            .WithMessage(ValidationErrors.EUC005.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.EUC005.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.EUC005.Message)
            .Numeric()
            .WithMessage(ValidationErrors.EUC009.Message);

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage(ValidationErrors.EUC006.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.EUC006.Message)
            .MaximumLength(50)
            .WithMessage(ValidationErrors.EUC006.Message);

        RuleFor(x => x.City)
            .NotNull()
            .WithMessage(ValidationErrors.EUC007.Message)
            .NotEmpty()
            .WithMessage(ValidationErrors.EUC007.Message)
            .MaximumLength(20)
            .WithMessage(ValidationErrors.EUC007.Message);
    } 
}

