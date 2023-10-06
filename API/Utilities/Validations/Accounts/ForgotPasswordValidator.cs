using API.Controllers;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(f => f.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
