using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountValidator()
        {
            RuleFor(a => a.Guid)
                .NotEmpty();

            RuleFor(a => a.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\",.<>?]");

            RuleFor(a => a.Otp)
                .NotEmpty();

            RuleFor(a => a.IsUsed)
                .NotEmpty();

            RuleFor(a => a.ExpiredTime)
                .NotEmpty();
        }
    }
}
