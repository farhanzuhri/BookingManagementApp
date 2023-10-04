using API.DTOs.Universities;
using FluentValidation;

namespace API.Utilities.Validations.Universities
{
    public class UpdateUniversityValidator : AbstractValidator<UniversityDto>
    {
        public UpdateUniversityValidator()
        {
            RuleFor(e => e.Guid)
                .NotEmpty();

            RuleFor(e => e.Code)
                .NotEmpty();

            RuleFor(e => e.Name)
                .NotEmpty();
        }
    }
}
