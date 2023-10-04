using API.DTOs.AccountRoles;
using FluentValidation;

namespace API.Utilities.Validations.AccountRoles
{
    public class UpdateAccountRoleValidator : AbstractValidator<AccountRoleDto>
    {
        //validator untuk update accountrole
        public UpdateAccountRoleValidator()
        {

            RuleFor(a => a.Guid)
                .NotEmpty();

            RuleFor(a => a.AccountGuid)
                .NotEmpty();

            RuleFor(a => a.RoleGuid)
                .NotEmpty();

        }
    }
}
