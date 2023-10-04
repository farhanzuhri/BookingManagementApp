using API.DTOs.Roles;
using FluentValidation;

namespace API.Utilities.Validations.Roles
{
    public class UpdateRolesValidator : AbstractValidator<RoleDto>
    {
        public UpdateRolesValidator()
        {
            RuleFor(e => e.Guid)
                .NotEmpty(); 

            RuleFor(e => e.Name)
                .NotEmpty().MaximumLength(100);

        }
    }
}
