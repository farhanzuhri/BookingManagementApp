using API.DTOs.Universities;
using FluentValidation;

namespace API.Utilities.Validations.Universities
{
    public class CreateUniversityValidator : AbstractValidator<CreateUniversityDto>
    {
        public CreateUniversityValidator()
        {
            // Validation rule for Code
            RuleFor(e => e.Code)
                .NotEmpty();

            // Validation rule for Name
            RuleFor(e => e.Name)
                .NotEmpty();
        }
    }
}
