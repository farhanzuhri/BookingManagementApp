using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validations.AccountRoles
{
    public class CreateAccountRoleValidator : AbstractValidator<CreateAccountRoleDto>
    {
        public CreateAccountRoleValidator()
        {
            RuleFor(ar => ar.AccountGuid)
                .NotEmpty();

            RuleFor(ar => ar.RoleGuid)
                .NotEmpty();
        }
    }
}

