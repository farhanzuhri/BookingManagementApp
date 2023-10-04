using API.DTOs.Educations;
using FluentValidation;

namespace API.Utilities.Validations.Educations
{
    public class UpdateEducationValidator : AbstractValidator<EducationDto>
    {
        public UpdateEducationValidator()
        {
            // Validation rule for Guid
            RuleFor(e => e.Guid)
                .NotEmpty();

            // Validation rule for Major
            RuleFor(e => e.Major)
                .NotEmpty().MaximumLength(100);

            // Validation rule for Degree
            RuleFor(e => e.Degree)
                .NotEmpty().MaximumLength(100);

            // Validation rule for GPA
            RuleFor(e => e.GPA)
                .NotEmpty();

            // Validation rule for UniversityGuid
            RuleFor(e => e.UniversityGuid)
                .NotEmpty();
        }
    }
}
