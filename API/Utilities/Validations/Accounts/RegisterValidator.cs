using API.DTOs.Accounts;
using API.Utilities.Enums;
using FluentValidation;

namespace API.Utilities.Validations.Accounts
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public float Gpa { get; set; }
        public string UniversityCode { get; set; }
        public string UniversityName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public RegisterValidator()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty();

            RuleFor(r => r.BirthDate)
                .NotEmpty()
                .LessThan(DateTime.Now.AddYears(-18));

            //notnull agar bisa isi 0
            RuleFor(r => r.Gender)
                .NotNull()
                .IsInEnum();

            RuleFor(r => r.HiringDate)
             .NotEmpty();

            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(r => r.PhoneNumber)
               .NotEmpty()
               .MinimumLength(9)
               .MaximumLength(20);

            RuleFor(r => r.Major)
                .NotEmpty();

            RuleFor(r => r.Degree)
                .NotEmpty();

            //membuat aturan gpa lebih dari 0.0 dan krang dr 4.0
            RuleFor(r => r.Gpa)
                .NotEmpty()
                .Must(gpa => gpa >= 0.0f && gpa <= 4.0f);

            RuleFor(r => r.Password)
              .NotEmpty()
              .MinimumLength(8)
              .Matches("[A-Z]")
              .Matches("[a-z]")
              .Matches("[0-9]")
              .Matches("[!@#$%^&*()_+\\-=\\[\\]{};':\",.<>?]");

            RuleFor(r => r.ConfirmPassword)
                .NotEmpty()
                .Equal(r => r.Password);

        }
    }
}
