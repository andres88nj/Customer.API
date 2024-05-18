using FluentValidation;

namespace Customer.Application.Validations;

public static class ValidationExtensions
{
    public static bool IsValidGuid(this string input) => Guid.TryParse(input, out var _);

    public static IRuleBuilderOptions<T, string> Numeric<T>(this IRuleBuilder<T, string> ruleBuilder)
    {
        return ruleBuilder.Must((string value) => string.IsNullOrEmpty(value) || value.ToCharArray().All((char c) => char.IsDigit(c))).WithMessage("The list contains too many items");
    }
}
