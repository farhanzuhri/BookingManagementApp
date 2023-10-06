using API.DTOs.Educations;
using API.DTOs.Universities;
using API.Models;
using API.Utilities.Enums;


namespace API.DTOs.Accounts
{
    public class RegisterDto
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

        //membuat implicit operator untuk create
        public static implicit operator Employee(RegisterDto employeeDto)
        {
            return new Employee
            {
                Guid = new Guid(),
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                BirthDate = employeeDto.BirthDate,
                Gender = employeeDto.Gender,
                HiringDate = employeeDto.HiringDate,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now

            };
        }

        public static implicit operator Education(RegisterDto createEducationDto)
        {
            return new Education
            {
                Major = createEducationDto.Major,
                Degree = createEducationDto.Degree,
                GPA = createEducationDto.Gpa,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now

            };
        }

        public static implicit operator University(RegisterDto createUniversityDto)
        {
            return new University
            {
                Guid = new Guid(),
                Code = createUniversityDto.UniversityCode,
                Name = createUniversityDto.UniversityName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,

            };
        }

        public static implicit operator Account(RegisterDto createAccountDto)
        {
            return new Account
            {
                Otp = 0,
                IsUsed = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,

            };
        }
    }
}
