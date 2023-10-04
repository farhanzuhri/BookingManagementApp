﻿using API.DTOs.Roles;
using FluentValidation;

namespace API.Utilities.Validations.Roles
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleValidator()
        {
            // Validation rule for Name
            RuleFor(e => e.Name)
                .NotEmpty();
        }
    }
}
