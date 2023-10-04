using API.DTOs.Accounts;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class UpdateAccountValidator : AbstractValidator<AccountDto>
    {
        public UpdateAccountValidator()
        {
            RuleFor(a => a.Guid)
                .NotEmpty();

            RuleFor(a => a.Otp)
                .NotEmpty();

            RuleFor(a => a.ExpiredTime)
                .NotEmpty();

            RuleFor(a => a.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]")
                .Matches("[a-z]")
                .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\",.<>?]");
            
            RuleFor(a => a.IsUsed)
                .NotEmpty();


        }
    }
}
