using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDto>
    {
        public ChangePasswordValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(a => a.NewPassword)
               .NotEmpty()
               .MinimumLength(8)
               .Matches("[A-Z]")
               .Matches("[a-z]")
               .Matches("[0-9]")
               .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\",.<>?]");

            RuleFor(c => c.ConfirmPassword)
                .NotEmpty()
                .Equal(c => c.NewPassword);

            RuleFor(c => c.OTP)
                .NotEmpty();

        }
    }
}
