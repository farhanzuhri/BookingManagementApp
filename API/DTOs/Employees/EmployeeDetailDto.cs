using API.DTOs.Accounts;

namespace API.DTOs.Employees
{
    public class EmployeeDetailDto
    {
        public Guid Guid { get; set; }
        public string Nik { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime HiringDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public float Gpa { get; set; }
        public string University { get; set; }

        public static explicit operator EmployeeDetailDto(RegisterDto RegisterDto)
        {
            return new EmployeeDetailDto
            {

                FullName = RegisterDto.FirstName + " " + RegisterDto.LastName,
                BirthDate = RegisterDto.BirthDate,
                Gender = RegisterDto.Gender.ToString(),
                HiringDate = RegisterDto.HiringDate,
                Email = RegisterDto.Email,
                PhoneNumber = RegisterDto.PhoneNumber,
                Major = RegisterDto.Major,
                Degree = RegisterDto.Degree,
                Gpa = RegisterDto.Gpa

            };
        }
    }
}
